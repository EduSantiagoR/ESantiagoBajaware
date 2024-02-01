namespace TEST
{
    [TestClass]
    public class EstadoCivil
    {
        [TestMethod]
        public void GetAll()
        {
            ML.Result result = BL.EstadoCivil.GetAll();
            Assert.IsNotNull(result.Objects);
            Assert.IsNull(result.Ex);
            Assert.IsTrue(result.Correct);
        }
    }
}