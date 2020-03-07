using Microsoft.AspNetCore.Mvc;

namespace explosiveapi.Controllers
{
    public class ExplosionController : ControllerBase
    {
        [Route ("api/[explosion]")]
        [ApiController]

        [HttpGet ("explosion")]
        public static string Explode (string s)
        {
            // Insert your solution here
            // split the string into numbers
            var answerString = "";
            foreach (var letter in s)
            {
                // find the value of each number
                var number = int.Parse (letter.ToString ());
                // duplicate the number value times
                for (var i = 0; i < number; i++)
                {
                    answerString += letter;
                }
            }
            // return a copy of the numbers duplicated
            return answerString;
        }
    }

}