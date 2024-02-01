namespace TEST
{
    [TestClass]
    public class Cliente
    {
        [TestMethod]
        public void GetAll()
        {
            ML.Result result = BL.Cliente.GetAll();
            Assert.IsNotNull(result.Objects);
            Assert.IsNull(result.Ex);
            Assert.IsTrue(result.Correct);
        }
        [TestMethod]
        public void GetById()
        {
            ML.Result result = BL.Cliente.GetById(101);
            Assert.IsNotNull(result.Object);
            Assert.IsNull(result.Ex);
            Assert.IsTrue(result.Correct);
        }
        [TestMethod]
        public void Add()
        {
            ML.Cliente cliente = new ML.Cliente();
            cliente.Nombre = "Eduardo";
            cliente.ApellidoPaterno = "Santiago";
            cliente.ApellidoMaterno = "Ramírez";
            cliente.FechaNacimiento = new DateTime(1994, 05, 05);
            cliente.EstadoCivil.IdEstadoCivil = 1;
            cliente.Nacionalidad.IdNacionalidad = 1;
            ML.Result result = BL.Cliente.Add(cliente);
            Assert.IsNull(result.Ex);
            Assert.IsTrue(result.Correct);
        }
        [TestMethod]
        public void Update()
        {
            ML.Cliente cliente = new ML.Cliente();
            cliente.CodCliente = 102;
            cliente.Nombre = "Eduardo";
            cliente.ApellidoPaterno = "Santiago";
            cliente.ApellidoMaterno = "Ramírez";
            cliente.FechaNacimiento = new DateTime(1994, 05, 05);
            cliente.EstadoCivil.IdEstadoCivil = 2;
            cliente.Nacionalidad.IdNacionalidad = 1;
            ML.Result result = BL.Cliente.Update(cliente);
            Assert.IsNull(result.Ex);
            Assert.IsTrue(result.Correct);
        }
        [TestMethod]
        public void Delete()
        {
            ML.Result result = BL.Cliente.Delete(102);
            Assert.IsNull(result.Ex);
            Assert.IsTrue(result.Correct);
        }
    }
}
