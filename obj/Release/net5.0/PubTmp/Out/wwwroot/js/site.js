// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


/* Write your JavaScript code.*/


$(document).ready(function () {

    //Chosen plugin
    jQuery(document).ready(function () {
        jQuery(".chosen").data("placeholder", "Assign Personel").chosen();
    });

    

    //Managing Projects
    $(document).on("click", ".projectBtn", (function (e) {
        e.preventDefault();
        e.stopImmediatePropagation();

        $.ajax({
            type: "GET",
            url: "Project/Create",
            success: function (res) {
                $("#form-modal-project .modal-body").html(res);
                $("#form-modal-project .modal-title").text("Create new project");
                $("#form-modal-project").modal("show");
            }
        });
    }))

    $(document).on("click", ".submitProject", (function (e) {
        e.preventDefault();
        e.stopImmediatePropagation();

        var title = $("#projectTitle").val();
        var description = $("#projectDescription").val();
        var ids = $("#personelSelect").val();
        


        $.ajax({
            type: "POST",
            url: "/Project/Create",
            data: {'prTitle': title, 'prDescription': description, 'UsersId': ids },
            success: function (res) {
                $(".prTitle").text(title);
                $(".prDescription").text(description);
                $(".prIndex").load(location.pathname + " .prIndex");
                Swal.fire({
                    position: 'top-end',
                    icon: 'success',
                    title: 'Project Added Successfuly',
                    showConfirmButton: false,
                    timer: 1500
                })
                $("#form-modal-project").modal("hide");
            },
            error: (error) => {
                console.log(JSON.stringify(error));
            }
        })
    }))

    $(document).on("click", ".delProject", (function (e) {
        e.preventDefault();
        e.stopImmediatePropagation();

        var id = this.id

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
                Swal.fire(
                    'Deleted!',
                    'Project has been deleted.',
                    'success'
                );
                $.ajax({
                    type: "POST",
                    url: "/Project/Delete/" + id,
                    success: function (res) {
                        $(".prIndex").load(location.pathname + " .prIndex")
                    }
                })
            }
        })
    }))

    $(document).on("click", ".delPersonel", (function (e) {
        e.preventDefault();
        e.stopImmediatePropagation();

        var id = this.id;

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
                Swal.fire(
                    'Deleted!',
                    'User has been removed from the project.',
                    'success'
                );
                $.ajax({
                    type: "POST",
                    url: "/Project/RemovePersonel/",
                    data: { 'idsString': id },
                    success: function (res) {
                        $(".personelTable").load(location.pathname + " .personelTable");
                    }
                })
            }
        })
    }))


    $(document).on("click", ".projectUpdateBtn", (function (e) {
        e.preventDefault();
        e.stopImmediatePropagation();

        var projectId = this.id;

        $.ajax({
            type: "GET",
            url: "/Project/Update/" + projectId,
            success: function (res) {
                $("#form-modal-project .modal-body").html(res);
                $("#form-modal-project").modal("show");
            }
        });
    }))

    $(document).on("click", ".saveProject", (function (e) {
        e.preventDefault();
        e.stopImmediatePropagation();

        var title = $("#projectTitle").val();
        var description = $("#projectDescription").val();
        var ids = $("#personelSelect").val();
        var prId = this.id;
       

        $.ajax({
            type: "POST",
            url: "/Project/Update",
            data: { 'id': prId, 'prTitle': title, 'prDescription': description, 'UsersId': ids },
            success: function (res) {
                $(".prTitle").text(title);
                $(".prDescription").text(description);
                $(".personelTable").load(location.pathname + " .personelTable");
                Swal.fire({
                    position: 'top-end',
                    icon: 'success',
                    title: 'Project Updated Successfuly',
                    showConfirmButton: false,
                    timer: 1500
                })
                $("#form-modal-project").modal("hide");
            },
             error: (error) => {
                console.log(JSON.stringify(error));
            }
        })
    }))

    //Managing Roles
    $(document).on("click", ".roleBtn", (function (e) {
        e.preventDefault();
        e.stopImmediatePropagation();

        var userId = this.id;

        $.ajax({
            type: "GET",
            url: "Role/Manage" + "?UserId=" + userId,
            success: function (res) {
                $("#form-modal-roles .modal-body").html(res);
                $("#form-modal-roles").modal("show");
            }
        });
    }))

    $(document).on("click", ".saveRole", (function (e) {
        e.preventDefault();
        e.stopImmediatePropagation();

        var userId = this.id;
        var selectedRole = $("#roleList option:selected").text();
        

        $.ajax({
            type: "POST",
            url: "Role/Manage",
            data: { 'userId': userId, 'role': selectedRole },
            cache: false,
            success: function (res) {
                 $("#roleTab").load(location.pathname + " #roleTab");
                
                Swal.fire({
                    position: 'top-end',
                    icon: 'success',
                    title: 'Role updated succesfully',
                    showConfirmButton: false,
                    timer: 1500
                })
                $("#form-modal-roles").modal("hide");
            }
        })
    }))

    //Tickets
    $(document).on("click", ".createTicketBtn", (function (e) {
        e.preventDefault();
        e.stopImmediatePropagation();

        var id = this.id;
       

        $.ajax({
            type: "GET",
            url: "/Ticket/Create",
            data: { 'projectId': id },
            success: function (res) {
                $("#form-modal-ticket .modal-body").html(res);
                $("#form-modal-ticket").modal("show");
            }
        });
    }))

    $(document).on("click", ".submitTicketBtn", (function (e) {
        e.preventDefault();
        e.stopImmediatePropagation();

        var projectId = $(".createTicketBtn").attr('id');
        var devId = $(".devSelect option:selected").val();
        var title = $("#ticketTitle").val();
        var description = $("#ticketDescription").val();
        var priority = $(".prioritySelect").val();
        var type = $(".typeSelect").val();

        $.ajax({
            type: "POST",
            url: "/Ticket/Create",
            data: { 'projectId': projectId, 'devId': devId, 'title': title, 'description': description, 'priority': priority, 'type': type },
            success: function (res) {
                $(".ticketTable").load(location.pathname + " .ticketTable");

                Swal.fire({
                    position: 'top-end',
                    icon: 'success',
                    title: 'Role updated succesfully',
                    showConfirmButton: false,
                    timer: 1500
                })

                $("#form-modal-ticket").modal("hide");
            }
        });
    }))



    $(document).on("click", ".updateTicketBtn", (function (e) {
        e.preventDefault();
        e.stopImmediatePropagation();

        var id = this.id;


        $.ajax({
            type: "GET",
            url: "/Ticket/Update/",
            data: { 'ticketId': id },
            success: function (res) {
                $("#form-modal-ticket .modal-body").html(res);
                $("#form-modal-ticket").modal("show");
            }
        });
    }))

    $(document).on("click", ".doneTicketRequestBtn", (function (e) {
        e.preventDefault();
        e.stopImmediatePropagation();

        var id = this.id;

        $.ajax({
            type: "POST",
            url: "/Ticket/DoneRequest",
            data: { 'ticketId': id },
            success: function (res) {
                $(".ticketIndex").load(location.pathname + " .ticketIndex");
                
            }
        })
    }))

    $(document).on("click", ".acceptTicketBtn", (function (e) {
        e.preventDefault();
        e.stopImmediatePropagation();

        var id = this.id;

        $.ajax({
            type: "POST",
            url: "/Ticket/Accept",
            data: { 'ticketId': id },
            success: function (res) {

                $(".ticketIndex").load(location.pathname + " .ticketIndex");
                
            }
        })
    }))

    $(document).on("click", ".rejectTicketBtn", (function (e) {
        e.preventDefault();
        e.stopImmediatePropagation();

        var id = this.id;

        $.ajax({
            type: "POST",
            url: "/Ticket/Reject",
            data: { 'ticketId': id },
            success: function (res) {
                $(".ticketIndex").load(location.pathname + " .ticketIndex");
                
            }
        })
    }))

    $(document).on("click", ".updateSubmitTicketBtn", (function (e) {
        e.preventDefault();
        e.stopImmediatePropagation();

        var ticketId = this.id;
        var devId = $(".devSelect option:selected").val();
        var title = $("#ticketTitle").val();
        var description = $("#ticketDescription").val();
        var priority = $(".prioritySelect").val();
        var type = $(".typeSelect").val();

        $.ajax({
            type: "POST",
            url: "/Ticket/Update",
            data: { 'ticketId': ticketId, 'devId': devId, 'title': title, 'description': description, 'priority': priority, 'type': type },
            success: function (res) {

                $("#ticketCard").load(location.href + " #ticketCard>*", "");
               

                Swal.fire({
                    position: 'top-end',
                    icon: 'success',
                    title: 'Role updated succesfully',
                    showConfirmButton: false,
                    timer: 1500
                })
                $("#form-modal-ticket").modal("hide");
            }
        });
    }))

    //Comments
    $(document).on("click", ".commentBtn", (function (e) {
        e.preventDefault();
        e.stopImmediatePropagation;

        var ticketId = this.id;
        var text = $("#commentText").val();

        $.ajax({
            type: "POST",
            url: "/Comment/Create",
            data: { 'ticketId': ticketId, 'text': text },
            success: function (res) {
                $("#commentDiv").load(location.href + " #commentDiv>*", "");
            }
        })
    }))

    $('.datatable').DataTable();
});