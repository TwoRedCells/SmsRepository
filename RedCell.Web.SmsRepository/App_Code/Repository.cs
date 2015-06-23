using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace RedCell.Web.SmsRepository
{
    /// <summary>
    /// Message repository.
    /// </summary>
    public sealed class Repository : XDocument
    {
        #region Constants
        private const string DefaultDefaultMessage = "Reply with [hello|bush|{0}]. +1678BATTERS brought to you by Red Cell Innovation Inc.";
        private const string DefaultPassword = "bingo";
        private const string DefaultKeyPattern = "[a-zA-Z0-9]{3,10}";
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="Repository"/> class.
        /// </summary>
        public Repository(string path) : base(
            new XDeclaration("1.0", "utf-8", "yes"),
            new XElement("repository",
                 new XElement("default", DefaultDefaultMessage),
                 new XAttribute("password", DefaultPassword),
                     new XAttribute("pattern", DefaultKeyPattern)))
        {
            Path = path;
            if (!File.Exists(path))
                Save(path);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the path.
        /// </summary>
        /// <value>The path.</value>
        public string Path { get; private set; }

        /// <summary>
        /// Gets or sets the repository password.
        /// </summary>
        /// <value>The repository password.</value>
        public string Password
        {
            get { return Root.Attribute("password").Value; }
            set { Root.Attribute("password").Value = value; }
        }

        /// <summary>
        /// Gets or sets the repository allowed pattern.
        /// </summary>
        /// <value>The repository allowed pattern.</value>
        public string KeyPattern
        {
            get { return Root.Attribute("pattern").Value; }
            set { Root.Attribute("pattern").Value = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds the specified message.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Set(string key, string value)
        {
            if (GetElement(key) == null)
                Root.Add(new XElement("message", new XAttribute("key", key), value));
            else
                GetElement(key).Value = value;
        }

        /// <summary>
        /// Gets the message with the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>System.String.</returns>
        public string Get(string key)
        {
            var element = GetElement(key);
            return element == null ? null : element.Value;
        }

        /// <summary>
        /// Gets the element.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>XElement.</returns>
        private XElement GetElement(string key)
        {
            return Root.Elements("message").SingleOrDefault(m => m.Attribute("key").Value == key);
        }

        /// <summary>
        /// Deletes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>System.String.</returns>
        public bool Delete(string key)
        {
            var element = Root.Elements("message").SingleOrDefault(m => m.Attribute("key").Value == key);
            if (element == null) return false;
            element.Remove();
            return true;
        }

        /// <summary>
        /// Loads this instance.
        /// </summary>
        public void Load()
        {
            var xml = XDocument.Load(Path);
            Root.ReplaceWith(xml.Root);
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            base.Save(Path);
        }

        /// <summary>
        /// Gets all keys.
        /// </summary>
        /// <returns>System.String[].</returns>
        public string[] GetAllKeys()
        {
            return Root.Elements("message").Select(m => m.Attribute("key").Value).ToArray();
        }
        #endregion
    }
}