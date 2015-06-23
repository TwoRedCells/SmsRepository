using System;

namespace RedCell.Web.SmsRepository
{
    /// <summary>
    /// A collection of Bushisms.
    /// </summary>
    public static class Bushisms
    {
        private readonly static string[] bushisms = 
        {
            "I promise you I will listen to what has been said here, even though I wasn't here.",
            "We spent a lot of time talking about Africa, as we should. Africa is a nation that suffers from incredible disease.",
            "You teach a child to read, and he or her will be able to pass a literacy test.",
            "I am here to make an announcement that this Thursday, ticket counters and airplanes will fly out of Ronald Reagan Airport.",
            "Tribal sovereignty means that; it's sovereign. I mean, you're a -- you've been given sovereignty, and you're viewed as a sovereign entity.",
            "I couldn't imagine somebody like Osama bin Laden understanding the joy of Hanukkah.",
            "You know, one of the hardest parts of my job is to connect Iraq to the war on terror.",
            "The same folks that are bombing innocent people in Iraq were the ones who attacked us in America on September the 11th.",
            "I'm the commander -- see, I don't need to explain -- I do not need to explain why I say things. That's the interesting thing about being president.",
            "Oh, no, we're not going to have any casualties.",
            "I think I was unprepared for war.",
            "I will not withdraw, even if Laura and Barney are the only ones supporting me.",
            "I hear there's rumors on the Internets that we're going to have a draft.",
            "I know how hard it is for you to put food on your family.",
            "Do you have blacks, too?",
            "This foreign policy stuff is a little frustrating.",
            "I don't think anybody anticipated the breach of the levees.",
            "I know the human being and fish can coexist peacefully.",
            "I would say the best moment of all was when I caught a 7.5 pound largemouth bass in my lake.",
            "They misunderestimated me.",
            "For every fatal shooting, there were roughly three non-fatal shootings. And, folks, this is unacceptable in America.",
            "This is an impressive crowd -- the haves and the have mores. Some people call you the elite -- I call you my base.",
            "Families is where our nation finds hope, where wings take dream.",
            "I know what I believe. I will continue to articulate what I believe and what I believe -- I believe what I believe is right.",
            "See, in my line of work you got to keep repeating things over and over and over again for the truth to sink in, to kind of catapult the propaganda.",
            "People say, how can I help on this war against terror? How can I fight evil? You can do so by mentoring a child; by going into a shut-in's house and say I love you.",
            "You forgot Poland.",
            "Goodbye from the world's biggest polluter.",
            "The British government has learned that Saddam Hussein recently sought significant quantities of uranium from Africa.",
            "The most important thing is for us to find Osama bin Laden. It is our number one priority and we will not rest until we find him.",
            "I don't know where bin Laden is. I have no idea and really don't care. It's not that important. It's not our priority.",
            "So what?",
            "Can we win? I don't think you can win it.",
            "I just want you to know that, when we talk about war, we're really talking about peace.",
            "I trust God speaks through me. Without that, I couldn't do my job.",
            "Major combat operations in Iraq have ended. In the battle of Iraq, the United States and our allies have prevailed.",
            "Those weapons of mass destruction have got to be somewhere!",
            "I'll be long gone before some smart person ever figures out what happened inside this Oval Office.",
            "Rarely is the question asked: Is our children learning?",
            "As yesterday's positive report card shows, childrens do learn when standards are high and results are measured.",
            "If this were a dictatorship, it'd be a heck of a lot easier, just so long as I'm the dictator.",
            "I'm the decider, and I decide what is best. And what's best is for Don Rumsfeld to remain as the Secretary of Defense.",
            "There's an old saying in Tennessee.I know it's in Texas, probably in Tennessee, that says, fool me once, shame on;shame on you. Fool me,you can't get fooled again.",
            "Too many good docs are getting out of the business. Too many OB-GYNs aren't able to practice their love with women all across this country.",
            "Our enemies are innovative and resourceful, and so are we. They never stop thinking about new ways to harm our country and our people, and neither do we.",
            "You work three jobs? ... Uniquely American, isn't it? I mean, that is fantastic that you're doing that.",
            "Brownie, you're doing a heck of a job.",
            "My answer is bring them on."
        };

        /// <summary>
        /// Gets a random quote.
        /// </summary>
        /// <returns>System.String.</returns>
        public static string GetRandom()
        {
            var rnd = new Random();
            return bushisms[rnd.Next(0, bushisms.Length - 1)];
        }
    }
}