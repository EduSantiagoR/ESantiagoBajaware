namespace TEST
{
    [TestClass]
    public class TipoCredito
    {
        [TestMethod]
        public void GetAll()
        {
            ML.Result result = BL.TipoCredito.GetAll();
            Assert.IsNotNull(result.Objects);
            Assert.IsNull(result.Ex);
            Assert.IsTrue(result.Correct);
        }
    }
}
