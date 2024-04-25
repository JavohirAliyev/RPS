using System.Security.Cryptography;
using System.Text;
using SHA3.Net;

namespace Itransition3{
    public class Crypto{
        //generating random key every time the method is called
        public string GenerateKey(){
            var rng = RandomNumberGenerator.Create();
            byte[] bytes = new byte[32];
            rng.GetBytes(bytes);

            return BitConverter.ToString(bytes).Replace("-","");
        }

        //computing SHA3-256 of computer's move (string)
        public string ComputerHMAC(string move){
            using (var shaAlg = Sha3.Sha3256()){
                var hash = shaAlg.ComputeHash(Encoding.UTF8.GetBytes(move));
                return Convert.ToHexString(hash);
            }
        }
    }
}
