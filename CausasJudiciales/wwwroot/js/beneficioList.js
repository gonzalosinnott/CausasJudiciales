var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/beneficio",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "numeroExpediente", "width": "15%" },
            { "data": "representado", "width": "15%" },
            { "data": "caratula", "width": "15%" },
            { "data": "testigos", "width": "15%" },
            { "data": "inicioDemanda", "width": "15%" },
            { "data": "traslado", "width": "15%" },
            { "data": "seDicteSentencia", "width": "15%" },
            { "data": "sentencia", "width": "15%" },
            { "data": "regulacion", "width": "15%" },
            { "data": "observaciones", "width": "15%" },

            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/Beneficios/Editar?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:80px;'>
                            EDITAR
                        </a>
                        &nbsp;
                        <a class='btn btn-danger text-white' style='cursor:pointer; width:80px;'
                            onclick=Delete('/api/beneficio?id='+${data})>
                            BORRAR
                        </a>
                        </div>`;
                }, "width": "20%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "¿Desea eliminar la causa seleccionada",
        text: "una vez eliminada, la causa no podra ser recuperada",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}