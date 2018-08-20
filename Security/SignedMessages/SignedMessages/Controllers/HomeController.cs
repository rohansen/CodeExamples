using SignedMessages.CryptoHelpers;
using SignedMessages.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SignedMessages.Controllers
{
    public class HomeController : Controller
    {
        string messageToValidate = "Ask Ronni for money, he wants to give everyone a million dollars!";
        public ActionResult Index()
        {
            //var keyinfo = CryptoHelpers.CryptoHelper.RSA(); already used this to generate a random private and public key
            //----------------
            var publicKeyInfo = System.IO.File.Open(Server.MapPath(@"~\PublicKey.xml"), FileMode.Open);
            var privateKeyInfo = System.IO.File.Open(Server.MapPath(@"~\PrivateKey.xml"), FileMode.Open);
            StreamReader publicKeyStream = new StreamReader(publicKeyInfo);
            StreamReader privateKeyStream = new StreamReader(privateKeyInfo);

            var privateCryptoParams = CryptoHelpers.CryptoHelper.GetCSPProviderFromXMLString(privateKeyStream.ReadToEnd());
            var publicCryptoParams = CryptoHelpers.CryptoHelper.GetCSPProviderFromXMLString(publicKeyStream.ReadToEnd());
            publicKeyInfo.Close();
            privateKeyInfo.Close();

            var publicKey = BouncyCastleHelpers.ExportPublicKey(publicCryptoParams);
            var privateKey = BouncyCastleHelpers.ExportPrivateKey(privateCryptoParams);

            var mac = CryptoHelper.CreateHMAC(messageToValidate, Encoding.Unicode.GetBytes(privateKey));

            ViewBag.MAC = mac;
            return View(new AssymetricKeyInformation { PublicKey = publicKey });
        }
        public ActionResult ValidateMACMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ValidateMACMessage(MACViewModel mvm)
        {
            bool isMacValid = CryptoHelper.ValidateHMAC(mvm.MAC, mvm.Message, Encoding.Unicode.GetBytes(mvm.PublicKey));
            ViewBag.Valid = isMacValid;
            return View();
        }
    }
}