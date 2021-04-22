var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/Trip",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "17%" },
            { "data": "countryName", "width": "17%" },
            { "data": "startDate", "width": "17%" },
            { "data": "endDate", "width": "17%" },
            { "data": "description", "width": "17%" },
            {
                "data": "iD",
                "render": function (data) {
                    return `<div class="text-center">
                         <a href="/TripList/Edit?=${data}" class='btn btn-success text-white' style='cursor:pointer;'>
                            Edit
                         </a>
                         &nbsp;
                        <a class='btn btn-danger text-white' style='cursor:pointer;' onclick=Delete('/api/Trip?id='+${data})>
                            Delete
                         </a>
                         </div>`;
                }, "width": "40%"
            }
        ],
        "language": {
            "emptyTable": "No Data Found"
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        buttons: true,
        dangerMode: true,
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(message);
                    }
                }
            });
        }
    });
}