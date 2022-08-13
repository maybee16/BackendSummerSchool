using ConsoleLibrary;
using WritelineLibrary;


Menu menu = new();
try
{
    menu.Run();
}
catch (Exception ex)
{
    ColorMessage.Get(ex.Message, ConsoleColor.Red);
}
