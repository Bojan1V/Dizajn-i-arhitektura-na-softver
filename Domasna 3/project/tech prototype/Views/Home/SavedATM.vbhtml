@Code
    ViewData("Title") = "SavedATM"
End Code

<style>
    li {
        list-style: none;
        border-bottom: 2px solid black;
        padding: 10px;
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
    <h3>При клик на зачуваниот банкомат ќе добиете достапни локации во градот кој што сте избрале</h3>
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

        $("#btnDelte").click(function () {
            debugger;
            var temp = $("#btnDelete").attr("data-attr");
            alert("vlegov" + temp);
            localStorage.removeItem("podatociZaBankata" + temp);
        });


    });


</script>

