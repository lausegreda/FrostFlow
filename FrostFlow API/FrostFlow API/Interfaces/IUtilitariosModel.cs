namespace FrostFlow_API.Interfaces
{
    public interface IUtilitariosModel
    {
        public string Encrypt(string texto);
        public string Decrypt(string texto);
    }
}
