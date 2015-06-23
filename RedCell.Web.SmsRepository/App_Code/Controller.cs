using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace RedCell.Web.SmsRepository
{
    /// <summary>
    /// Messaging controller.
    /// </summary>
    public sealed class Controller
    {
        #region Constants
        private const string DefaultMessage = "Reply with [hello|bush|{0}]. 530-PROJECT brought to you by Red Cell Innovation Inc.";
        private const string RepositoryFilename = "repository.xml";
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="Controller"/> class.
        /// </summary>
        /// <param name="dataDirectory">The data directory.</param>
        public Controller(string dataDirectory)
        {
            DataDirectory = dataDirectory;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the data directory.
        /// </summary>
        /// <value>The data directory.</value>
        public string DataDirectory { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Parse the twilio request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response</returns>
        public string ParseTwilioRequest(string request)
        {
            // Load repository.
            var repositoryPath = Path.Combine(DataDirectory, RepositoryFilename);
            var repository = new Repository(repositoryPath);
            repository.Load();

            // Parse the twilio request.
            string command = string.Empty, message = null, password = null, key = null;
            var matches = Regex.Match(request, "^(?<command>[^ ]+) (?<key>[^ ]+) (?<password>[^ ]+)(?: (?<message>.*))?$|^(?<command>[^ ]+)(?: (?<values>.*))?$");
            if (matches.Groups["command"].Success)
                command = matches.Groups["command"].Value.ToLower();
            if (matches.Groups["message"].Success)
                message = matches.Groups["message"].Value;
            if (matches.Groups["key"].Success)
                key = matches.Groups["key"].Value;
            if (matches.Groups["password"].Success)
                password = matches.Groups["password"].Value;

            switch (command)
            {
                case "hello":
                    return "Hi there.";

                case "ping":
                    return "Pong.";

                case "set":
                    if (password != repository.Password) return "Wrong password.";
                    if (!Regex.IsMatch(key, repository.KeyPattern))
                        return string.Format("{0} is an invalid key.", key);
                    repository.Set(key, message);
                    repository.Save();
                    return string.Format("{0} set: {1}", key, message);

                case "delete":
                    if (password != repository.Password) return "Wrong password.";
                    if (repository.Delete(key))
                    {
                        repository.Save();
                        return string.Format("{0} deleted.", key);
                    }
                    else
                    {
                        return string.Format("{0} does not exist.", key);
                    }

                case "bush":
                    return Bushisms.GetRandom();
                
                case null: // Invoked below.
                    var keys = string.Join("|", repository.GetAllKeys());
                    return string.Format(DefaultMessage, keys);

                default:
                    // Empty request.
                    if (string.IsNullOrEmpty(command)) goto case null;

                    // Known value.
                    var msg = repository.Get(command);
                    if (msg != null) return msg;

                    // Unknown value.
                    goto case null;
            }
        }

        /// <summary>
        /// Writes the twilio response.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>XDocument.</returns>
        public XDocument WriteTwilioResponse(string message)
        {
            return new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("Response",
                    new XElement("Sms", message)));
        }
        #endregion
    }
}