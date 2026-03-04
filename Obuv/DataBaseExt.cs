namespace Obuv.Context;

public partial class DataBase
{
    private static DataBase? _shared;
    public static DataBase Shared => _shared ??= new DataBase();
}