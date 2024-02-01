namespace TEST
{
    [TestClass]
    public class Credito
    {
        [TestMethod]
        public void GetByCodCredito()
        {
            ML.Result result = BL.Credito.GetByCodCliente(101);
            Assert.IsNotNull(result.Objects);
            Assert.IsNull(result.Ex);
            Assert.IsTrue(result.Correct);
        }
    }
}
