@Code
    ViewData("Title") = "SavedATM"
End Code

<style>
    li {
        list-style: none;
        border-bottom: 2px solid black;
        padding: 10px;
    }
    li img{
        display:none;
    }
    li button{
        display:none;
    }

    .btn-danger {
        position: relative;
        float: right;
        top: -50px;
    }
</style>
<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js"></script>

<div class="jumbotron">
    <h3>Зачувани банкомати</h3>
    <h6>При клик на копчето "Избриши" ќе ја избришите локацијата на бакоматот</h6>
</div>

<div id="zacuvaniBankomati">
    <ul>
        
    </ul>
</div>

<script type="text/javascript">
    $(document).ready(function () {
        var test = localStorage.getItem("test");
        for (var i = 1; i <= test - 1; i++) {
            var brojac = test - 1;
            var bankomati = localStorage.getItem("podatociZaBankata" + i);
            $("#zacuvaniBankomati").append("<li>" + bankomati + "</li>" + "<button class='btn btn-danger' type='button' id='btnDelete' 'data-attr=" + brojac + ">Избриши</button>");
        }

        $("#btnDelete").click(function () {
            debugger;
            var temp = $("#btnDelete").attr("data-attr");
            alert("vlegov" + temp);
            localStorage.removeItem("podatociZaBankata" + temp);
        });


    });


</script>

