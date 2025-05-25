namespace Sipcon.WebApp.Client.Enum
{
    

    public class StringValueAttribute : Attribute
    {
        public string Value { get; }

        public StringValueAttribute(string value)
        {
            Value = value;
        }
    }

    public static class EnumExtensions
    {
        public static string GetStringValue(this MessageEnum enumValue) 
        {
            return enumValue.GetType().GetMember(enumValue.ToString())
                .FirstOrDefault(m => m.GetCustomAttributes(typeof(StringValueAttribute), false)
                    .Cast<StringValueAttribute>()
                    .FirstOrDefault() != null)
                ?.GetCustomAttributes(typeof(StringValueAttribute), false)
                .Cast<StringValueAttribute>()
                .FirstOrDefault()?.Value ?? "Error mensaje!....";
        }
    }

    public enum MessageEnum
    {
        // General
        [StringValue("Registro guardado satisfactoriamente...")]
        SaveOK,
        [StringValue("Problemas al guardar registro!...")]
        SaveNotOK,
        [StringValue("Problemas al cargar registro!...")]
        GetError,

        // ActionsMethod
        [StringValue("Acción no reconocida!...")]
        ActionsError,



        // Imports
        [StringValue("Archivo importado Satisfactoriamente...")]
        ImportOK,
        [StringValue("Problemas al importar Archivo!...")]
        ImportNotOK,
        [StringValue("Error al importar Archivo, esta vacio!...")]
        ImportError,
        [StringValue("Tamaño del archivo excede el limite maximo permitido de 10MB!...")]
        ImportErrorMaxByte,

        // Exports
        [StringValue("Problemas al exportar Archivo!...")]
        ExportNotOK,

        // Activate
        [StringValue("Registro activado Satisfactoriamente...")]
        ActivateOK,
        [StringValue("Problemas al activar registros!...")]
        ActivateNotOK,

        // Desactivate
        [StringValue("Registro inactivado Satisfactoriamente...")]
        DeactivateOK,
        [StringValue("Problemas al inactivar registros!...")]
        DeactivateNotOK,

        //Assign
        [StringValue("Registro asignado Satisfactoriamente...")]
        AssignOK,
        [StringValue("Problemas al asignar Registros!...")]
        AssignNotOK,

        //Unassign
        [StringValue("Registro Desasignado Satisfactoriamente...")]
        UnassignOK,
        [StringValue("Problemas al desasignar Registros!...")]
        UnassignNotOK,

        //Available
        [StringValue("Registro habilitado Satisfactoriamente...")]
        AvailableOK,
        [StringValue("Problemas al habilitar Registros!...")]
        AvailableNotOK,

        //Unavailable
        [StringValue("Registro inhabilitado Satisfactoriamente...")]
        UnavailableOK,
        [StringValue("Problemas al inhabilitar Registros!...")]
        UnavailableNotOK,

    }

}
