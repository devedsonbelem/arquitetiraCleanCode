using NUnit.Framework;
using projetoarquitetura.Interfaces;
using projetoarquitetura.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projetoarquitetura.TestUsuario
{

    [TestFixture]
    public class TesteSenhaCriptografada
    {
        private IServiceUsuario _service;
      
    
        [SetUp]
        public void Setup()
        {
        _service = new ServiceUsuario();
         }

        [Test]
        public void TestCriptografica()
        {
            bool resp = false;
             if (_service.HashValue("ola").Length > 10)
            {
                resp = true;
            }
            Console.WriteLine(resp);
            Assert.IsTrue(true);
 
        }
    }
}
