
//DataTables
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    DataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/admin/product/getall",
            "dataSrc": "data"
        },
        "columns": [ 
            { data: 'title' , "width" : "25%" },
            { data: 'isbn', "width": "15%" },
            { data: 'price', "width": "10%" },
            { data: 'author', "width": "20%" },
            { data: 'category.name', "width": "15%" },
            {
                data: 'id',
                "render": function (data, type, row) {
                    return `<div class="btn-group" role="group">
        <a href="/admin/product/upsert?id=${data}" class="btn btn-primary btn-sm me-3">
           <i class="bi bi-pencil-fill me-1" style="font-size: 0.8rem;"></i> Edit
        </a>
        <a class="btn btn-danger btn-sm" onClick=Delete('/admin/product/Delete/${data}') >
            <i class="bi bi-trash3-fill me-1" style="font-size: 0.8rem;"></i> Delete
        </a>
    </div>`;
                },
                "width": "20%"
            }
        ]
    });
}


//function confirmDelete(title) {
//    return confirm("Are you sure you want to delete " + title + " product ?");
//	}

// SweetAlert
 function Delete (url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            // ابعت طلب حذف للسيرفر
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        Swal.fire('Deleted!', data.message, 'success');
                        $('#tblData').DataTable().ajax.reload();
                    } else {
                        Swal.fire('Error!', data.message, 'error');
                    }
                }
            });
        }
    });
};


