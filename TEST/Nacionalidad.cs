namespace TEST
{
    [TestClass]
    public class Nacionalidad
    {
        [TestMethod]
        public void GetAll()
        {
            ML.Result result = BL.Nacionalidad.GetAll();
            Assert.IsNotNull(result.Objects);
            Assert.IsNull(result.Ex);
            Assert.IsTrue(result.Correct);
        }
    }
}
