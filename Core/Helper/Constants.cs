namespace AlkemyWallet.Core.Helper;

public static class Constants
{
    // transaction message
    public const string TRAN_NOT_EXISTS = "No existe una transacción con el id proporcionado asociada al usuario";
    public const string TRAN_DELETED = "La transacción ha sido eliminada";
    public const string TRAN_NOT_FOUND = "No se encontró la transacción";
    public const string TRAN_UPDATED = "Transacción modificada con éxito";
    public const string TRAN_CREATED = "Transacción creada con éxito";
    public const string TRAN_NOT_CREATED = "Transacción incorrecta. No se procedió con la creación";

    // Account message
    public const string ACC_NOT_FOUND_MESSAGE = "El id de la cuenta que ingreso no fue encontrado.";
    public const string ACC_BLOCK_MESSAGE = "Su cuenta esta bloqueada, no puede realizar operaciones.";
    public const string ACC_AMOUNT_LESS_THAN_ZERO_MESSAGE = "El importe ingresado debe ser mayor a 0";

    public const string ACC_PENDING_TRANSACTIONS_MESSAGE =
        "No se puede eliminar la cuenta mientras tenga inversiones o depositos pendientes";

    public const string DB_NOT_EXPECTED_RESULT_MESSAGE = "Algo ha salido mal cuando se intento guardar los cambios!!!";
    public const string ACC_DELETED_MESSAGE = "Cuenta eliminada.";

    public const string ACC_INSUFFICIENT_FUNDS_MESSAGE =
        "El dinero disponible en la cuenta es menor que el importe a transferir.";

    public const string ACC_SAME_ACCOUNT_MESSAGE =
        "La cuenta de destino es igual a la de origen. No se puede transferir a la misma cuenta.";

    public const string ACC_TRANSFER_SUCCESSFUL_MESSAGE = "Transferencia exitosa.";
    public const string ACC_BLOCK_SUCCESSFUL_MESSAGE = "La cuenta ha sido Bloqueada.";
    public const string ACC_UNBLOCK_SUCCESSFUL_MESSAGE = "La cuenta ha sido Desbloqueada.";
    public const string ACC_SUCCESSFUL_ACCOUNT_MESSAGE = "Se ha creado la cuenta exitosamente";
    public const string ACC_SUCCESSFUL_ACCOUNT_MODIFIED_MESSAGE = "Cuenta Modificada con exito";

    public const string ACC_NOT_MATCHED_MESSAGE =
        "El id de cuenta ingresado no coincide con el id de usuario registrado en el sistema";


    // User Message
    public const string USER_LOGGED_MESSAGE = "Datos de usuario loggueado";

    public const string USER_EMAIL_OR_PASSWORD_INCORRECT_MESSAGE =
        "El email o la contraseña no coinciden con lo registrado en la base de datos";

    public const string USER_NOT_FOUND_MESSAGE = "Usuario No Encontrado";
    public const string USER_SUCCESSFUL_MODIFIED_MESSAGE = "Usuario Modificado con exito";
    public const string USER_DELETED_MESSAGE = "El usuario ha sido eliminado";
    public const string USER_UNAUTHORIZED_MESSAGE = "Usted no está autorizado";
    public const string USER_DONT_HAVE_PERMISSIONS = "Usted no tiene permisos sobre este recurso";
    public const string USER_REGISTERED_EMAIL_MESSAGE = "El email que ingreso ya se encuentra registrado";
    public const string USER_SUCCESSFUL_ADDED_MESSAGE = "Usuario agregado con exito";
    public const string USER_EMAIL_INCORRECT_MESSAGE = "El email no cumple con los parámetros requeridos";

    public const string USER_INSUFFICIENT_POINTS_MESSAGE =
        "No tiene los puntos suficientes para adquirir este producto.";

    public const string USER_SUCCESSFUL_OPERATION_MESSAGE = "La operación ha sido exitosa. Muchas gracias!!.";

    // Catalogue Message
    public const string CAT_NOT_FOUND_MESSAGE = "No existe ningún catalogo con el id especificado";
    public const string CAT_NOT_FOUND_PAGE = "Esta buscando una pagina mas alla de la la ultima";

    public const string CAT_INSUFFICIENT_POINTS_MESSAGE =
        "No cuenta con los puntos suficientes para adquirir algun producto.";

    public const string CAT_SUCCESSFUL_MESSAGE = "Se ha creado el Catalogo exitosamente";
    public const string CAT_DELETED_MESSAGE = "el catalogo ha sido eliminada";
    public const string CAT_SUCCESSFUL_MODIFIED_MESSAGE = "Catalogo Modificado con exito";

    //FixedTermDeposit Message
    public const string FIX_NOT_FOUND_OR_USER_INVALID_MESSAGE =
        "No existe inversion con ese id o esta intentando consultar inversiones de otros usuarios.";

    public const string FIX_NOT_FOUND_MESSAGE = "No se encontro ninguna inversion con ese id.";
    public const string FIX_DELETED_MESSAGE = "La inversion ha sido eliminada";
    public const string FIX_SUCCESSFUL_MODIFIED_MESSAGE = "La inversion ha sido Modificada con exito";
    public const string FIX_SUCCESSFUL_MESSAGE = "Se ha creado la inversion exitosamente";

    //Role Message
    public const string ROL_NOT_FOUND_MESSAGE = "No se encontro ningun Role con ese id.";
    public const string ROL_SUCCESSFUL_MODIFIED_MESSAGE = "El Role ha sido Modificado con exito";
    public const string ROL_DELETED_MESSAGE = "El Role ha sido eliminada";
    public const string ROL_REGISTERED_MESSAGE = "El Role que intenta registrar ya existe.";
    public const string ROL_SUCCESSFUL_ADDED_MESSAGE = "Role Agregado con exito";

    //Image Message

    public const string IMG_FORMAT_NOT_SUPPORTED_MESSAGE = "El formato de imagen no es admitido";
    public const string IMG_TOO_BIG_MESSAGE = "La imagen debe ser menor a 10MB";
}