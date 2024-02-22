// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
new DataTable('#dataTableApp', {
    layout: {
        topStart: {
            buttons: ['copy', 'csv', 'excel', 'pdf', 'print']
        }
    }
});

//async function showMessage(result) {
//    if (result) {
//        await Swal.fire({
//            title: 'Éxito',
//            text: 'La transacción se ha guardado exitosamente.',
//            icon: 'success',
//            confirmButtonText: 'Aceptar'
//        });
//        window.location.href = '@Url.Action("Index", "Home")';
//    } else {
//        await Swal.fire({
//            title: 'Error',
//            text: 'Ha ocurrido un error al guardar la transacción.',
//            icon: 'error',
//            confirmButtonText: 'Aceptar'
//        });
//    }
//}