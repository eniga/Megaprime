using Microsoft.AspNetCore.Mvc;

namespace Megaprime.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrimeController : ControllerBase
    {
        [HttpGet("GetPrimes")]
        public IActionResult GetPrimes(int value)
        {
            List<int> primes = new();
            if(value <= 1)
                return Ok(primes);

            for(var i = 2; i <= value; i++)
            {
                if(i > 9)
                {
                    if (IsMegaPrime(i) && IsPrime(i))
                        primes.Add(i);
                }
                else
                {
                    if(IsPrime(i))
                        primes.Add(i);
                }
            }
            return Ok(primes);
        }

        private bool IsPrime(int value)
        {
            bool result = value < 2 ? false : true;
            for(var i = 2; i < value; i++)
            {
                if(value % i == 0)
                    return false;
            }
            return result;
        }

        private bool IsMegaPrime(int value)
        {
            bool result = true;
            List<int> values = value.ToString().ToCharArray().Select(x => { return int.Parse(x.ToString()); }).ToList();
            values.ForEach(x =>
            {
                if (!IsPrime((int)x))
                    result = false;
            });
            return result;
        }
    }
}
