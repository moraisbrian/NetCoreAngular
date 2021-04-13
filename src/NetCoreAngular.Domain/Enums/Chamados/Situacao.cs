namespace NetCoreAngular.Domain.Enums.Chamados
{
    public enum Situacao
    {
        IniciandoChamado = 0,
        AguardandoRespostaCliente = 1,
        AguardandoRespostaAtendente = 2,
        Cancelado = 3,
        Finalizado = 4
    }
}