@Code
    ViewData("Title") = "SearchATM"
End Code

<style>
    h5 .grad_selection {
        border: 1px solid #a7a9ac;
        border-radius: 3px;
        color: #464646;
        padding: 8px 8px 8px 15px;
        font-weight: 400;
        height: 39px;
        background-color: #fff;
    }

    #map {
        height: 500px;
    }

    .leaflet-popup-content img {
        margin-bottom: 10px;
        margin-left: 20%;
        width: 100px !important;
        height: 100px !important;
    }
    #grad{
        display:none;
    }
    #posta{
        display:none;
    }
   
</style>

<link rel="stylesheet" href="https://unpkg.com/leaflet@1.7.1/dist/leaflet.css"
      integrity="sha512-xodZBNTC5n17Xt2atTPuE1HxjVMSvLVW9ocqUKLsCC5CXdbqCmblAshOMAS6/keqq/sMZMZ19scR4PsZChSR7A=="
      crossorigin="" />
<script src="https://unpkg.com/leaflet@1.7.1/dist/leaflet.js"
        integrity="sha512-XQoYMqMTK8LvdxXYG3nZ448hOEQiglfqkJs1NOQV44cWnUrBc8PkAOcXy20w0vlaXaVUearIOBhiXZ5V3ynxwA=="
        crossorigin=""></script>

<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js"></script>


<div class="jumbotron">
    <h3>Пребарувајте банкомати така што ќе одберете според што сакате да ви бидат прикажани</h3>
</div>

<h5 id="izbor">
    Изберете според што сакате да пребарувате:<select class="ponudi" style="width: 100%">
    <option value="0">Цел регион</option>
    <option value="1">Град</option>
    <option value="2">Поштенски број</option>
    </select>
</h5>
<script type="text/javascript">
    $(document).ready(function () {

        $('.ponudi').change(function () {
            var selectedValue = parseInt(jQuery(this).val());

            switch (selectedValue) {
                case 0:
                    map.setView([41.6086, 21.7453], 8);
                    $("#posta").hide();
                    $("#grad").hide();
                    break;
                case 1:
                    $("#grad").show();
                    $("#posta").hide();
                    break;
                case 2:
                    $("#posta").show();
                    $("#grad").hide();
                    break;
                default:
                    alert("catch default");
                    break;
            }
        });
    });
</script>
@* dropdown pole, za lista na gradovi *@
<h5 id="grad">
    Изберете град: <select name="vrsta" class="grad_selection" style="width: 100%">
    <option value="0"></option>
    <option value="1">Скопје</option>
    <option value="2">Берово</option>
    <option value="3">Битола</option>
    <option value="4">Богданци</option>
    <option value="5">Валандово</option>
    <option value="6">Велес</option>
    <option value="7">Виница</option>
    <option value="8">Гевгелија</option>
    <option value="9">Гостивар</option>
    <option value="10">Делчево</option>
    <option value="11">Демир Капија</option>
    <option value="12">Демир Хисар</option>
    <option value="13">Кавадарци</option>
    <option value="14">Кичево</option>
    <option value="15">Кочани</option>
    <option value="16">Кратово</option>
    <option value="17">Крива Паланка</option>
    <option value="18">Крушево</option>
    <option value="19">Куманово</option>
    <option value="20">Македонски Брод</option>
    <option value="21">Неготино</option>
    <option value="22">Охрид</option>
    <option value="23">Прилеп</option>
    <option value="24">Пробиштип</option>
    <option value="25">Радовиш</option>
    <option value="26">Ресен</option>
    <option value="27">Свети Николе</option>
    <option value="28">Струга</option>
    <option value="29">Струмица</option>
    <option value="30">Тетово</option>
    <option value="31">Штип</option>
    <option value="32">Дојран</option>
</select>
</h5>

<h5 id="posta">
    Изберете поштенски број: <select name="vrsta" class="grad_selection" style="width: 100%">
         <option value="0"></option>
        <option value="1">1000</option>
        <option value="2">2330</option>
        <option value="3">7000</option>
        <option value="4">1484</option>
        <option value="5">2460</option>
        <option value="6">1400</option>
        <option value="7">2310</option>
        <option value="8">1480</option>
        <option value="9">1230</option>
        <option value="10">2320</option>
        <option value="11">1442</option>
        <option value="12">7240</option>
        <option value="13">1430</option>
        <option value="14">6250</option>
        <option value="15">2300</option>
        <option value="16">1360</option>
        <option value="17">1330</option>
        <option value="18">7550</option>
        <option value="19">1300</option>
        <option value="20">6530</option>
        <option value="21">1440</option>
        <option value="22">6000</option>
        <option value="23">7500</option>
        <option value="24">2210</option>
        <option value="25">2420</option>
        <option value="26">7310</option>
        <option value="27">2220</option>
        <option value="28">6330</option>
        <option value="29">2400</option>
        <option value="30">1200</option>
        <option value="31">2000</option>
        <option value="32">1485</option>
    </select>
</h5>

@* prikaz na mapa *@
<div id="map"></div>

<script type="text/javascript">
    $(document).ready(function () {

        $('.grad_selection').change(function () {
            var selectedValue = parseInt(jQuery(this).val());

            switch (selectedValue) {
                case 0:
                   
                case 1:
                    map.setView([41.9933528, 21.41643333333333], 12);
                    break;
                case 2:
                    map.setView([41.7061, 22.8552], 12);
                    break;
                case 3:
                    map.setView([41.0307194, 21.335644444444444], 12);
                    break;
                case 4:
                    map.setView([41.20326576594387, 22.57578853514908], 12);
                    break;
                case 5:
                    map.setView([41.31704337129702, 22.561301816106507], 12);
                    break;
                case 6:
                    map.setView([41.71730410755008, 21.77231307367105], 12);
                    break;
                case 7:
                    map.setView([41.88312979095288, 22.507960251069424], 12);
                    break;
                case 8:
                    map.setView([41.14534460873119, 22.499603072789782], 12);
                    break;
                case 9:
                    map.setView([41.80319089590413, 20.907722625252163], 12);
                    break;
                case 10:
                    map.setView([41.970862056640044, 22.773842701804263], 12);
                    break;
                case 11:
                    map.setView([41.4088264059753, 22.242312374349343], 12);
                    break;
                case 12:
                    map.setView([41.221512173963696, 21.20226684546518], 12);
                    break;
                case 13:
                    map.setView([41.43306606640899, 22.009620019228148], 12);
                    break;
                case 14:
                    map.setView([41.51328468100742, 20.952890856392077], 12);
                    break;
                case 15:
                    map.setView([41.91641442148661, 22.408740462599763], 12);
                    break;
                case 16:
                    map.setView([42.08009171031323, 22.179950717198665], 12);
                    break;
                case 17:
                    map.setView([42.20597556322446, 22.330221371393257], 12);
                    break;
                case 18:
                    map.setView([41.37053203437067, 21.248152529559157], 12);
                    break;
                case 19:
                    map.setView([42.132856804555324, 21.728708767336578], 12);
                    break;
                case 20:
                    map.setView([41.51653418842644, 21.20625842263067], 12);
                    break;
                case 21:
                    map.setView([41.48285219359036, 22.095196129434306], 12);
                    break;
                case 22:
                    map.setView([41.123171997922626, 20.801410121824073], 12);
                    break;
                case 23:
                    map.setView([41.37626908012308, 21.553481236939838], 12);
                    break;
                case 24:
                    map.setView([41.99479171592476, 22.18513895489765], 12);
                    break;
                case 25:
                    map.setView([41.634106037680326, 22.467051553680662], 12);
                    break;
                case 26:
                    map.setView([41.09051600525266, 21.01327050024699], 12);
                    break;
                case 27:
                    map.setView([41.86575671200071, 21.937326197944305], 12);
                    break;
                case 28:
                    map.setView([41.17780469079737, 20.67835993358623], 12);
                    break;
                case 29:
                    map.setView([41.437817913525336, 22.642013413672956], 12);
                    break;
                case 30:
                    map.setView([42.006547660944776, 20.97176838472546], 12);
                    break;
                case 31:
                    map.setView([41.746287893094056, 22.19974610392474], 12);
                    break;
                case 32:
                    map.setView([41.18099821224105, 22.72212190498387], 12);
                    break;
                default:
                    alert("catch default");
                    break;
            }
        });
    });

    var map = L.map('map').setView([41.6086, 21.7453], 8);

    //racno vneseni lokacii za prikaz na mapa
    var locations = [
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Народен фронт&ldquo; бр. 19а ТЦ Беверли Хилс</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="1">Зачувај Банкомат</button>', 41.9933528, 21.41643333333333],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>бул. &bdquo;Јане Сандански&ldquo; бр. 26, влез 2, локал 4</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="2">Зачувај Банкомат</button>', 41.9864528, 21.46371667],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p style="margin-left: 35px;">ул. "adresa" бр. 43/1-1</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="3">Зачувај Банкомат</button>', 41.9949083, 21.42761944],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p style="margin-left: 35px;">ул. "adresa" бр. 43/1-1</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="4">Зачувај Банкомат</button>', 41.9760417, 21.44379444],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>бул. &bdquo;Партизански одреди&ldquo; бр. 171а</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="5">Зачувај Банкомат</button>', 42.0092, 21.36603889],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;16-та Македонска бригада&ldquo; бр. 2/3</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="6">Зачувај Банкомат</button>', 42.0030361, 21.46018861],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>бул. &bdquo;Александар Македонски&ldquo; бр. 26 б</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="7">Зачувај Банкомат</button>', 42.0026333, 21.47454722],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Гоце Делчев&ldquo; бр. 38</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="8">Зачувај Банкомат</button>', 42.1356889, 21.71759444],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;ЈНА&ldquo; бр. 102</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="9">Зачувај Банкомат</button>', 42.1334917, 21.70951944],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;8-ми Септември&ldquo; бр. 44</p></p><button type="button" id="btnSave" onclick="clickMe()" data-attr="10">Зачувај Банкомат</button>', 41.7167611, 21.78253333],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>бул. &bdquo;Илинденска&ldquo; бр. 2 б </p><button type="button" id="btnSave" onclick="clickMe()" data-attr="11">Зачувај Банкомат</button>', 42.0110806, 20.97228611],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Илирија&ldquo; бр. 40 контакт </p><button type="button" id="btnSave" onclick="clickMe()" data-attr="12">Зачувај Банкомат</button>', 42.0091667, 20.97178333],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Методиј Андонов Ченто&ldquo; бр. 4</p></p><button type="button" id="btnSave" onclick="clickMe()" data-attr="13">Зачувај Банкомат</button>', 42.0102528, 20.97423611],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Илинденска&ldquo; бр. 226 </p><button type="button" id="btnSave" onclick="clickMe()" data-attr="14">Зачувај Банкомат</button>', 41.9975694, 20.96088056],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Скопски пат&ldquo; бр. 8 </p><button type="button" id="btnSave" onclick="clickMe()" data-attr="15">Зачувај Банкомат</button>', 42.0040917, 20.98945556],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Иво Лола Рибар&ldquo; бр. 18</p></p><button type="button" id="btnSave" onclick="clickMe()" data-attr="16">Зачувај Банкомат</button>', 41.7924611, 20.910016666666664],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Македонски просветители&ldquo; бр. 8в </p><button type="button" id="btnSave" onclick="clickMe()" data-attr="17">Зачувај Банкомат</button>', 41.1155528, 20.801355555555556],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Пролетерски бригади&ldquo; бр. 43 </p><button type="button" id="btnSave" onclick="clickMe()" data-attr="18">Зачувај Банкомат</button>', 41.180748841584986, 20.67597807548043],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Кузман Јосифовски Питу&ldquo; бр. 10 </p><button type="button" id="btnSave" onclick="clickMe()" data-attr="19">Зачувај Банкомат</button>', 41.5124722, 20.96325],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>бул. &bdquo;8-ми Септември&ldquo; бр. 1/3 </p><button type="button" id="btnSave" onclick="clickMe()" data-attr="20">Зачувај Банкомат</button>', 41.524301704326575, 20.526651634094378],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Столарска&ldquo; бр. 7 </p><button type="button" id="btnSave" onclick="clickMe()" data-attr="21">Зачувај Банкомат</button>', 41.0307194, 21.335644444444444],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;1-ви Мај&ldquo; бр. 204/4</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="22">Зачувај Банкомат</button>', 41.0312694, 21.336105555555555],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Борис Кидрич&ldquo; бб</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="23">Зачувај Банкомат</button>', 41.3481472, 21.556672222222222],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Ванчо Прќе&ldquo; бр. 67 </p><button type="button" id="btnSave" onclick="clickMe()" data-attr="24">Зачувај Банкомат</button>', 42.1356889, 21.717594444444444],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Кеј на Револуцијата&ldquo; бр. 13 </p><button type="button" id="btnSave" onclick="clickMe()" data-attr="25">Зачувај Банкомат</button>', 41.91915794703534, 22.410881619379325],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Никола Карев&ldquo; </p><button type="button" id="btnSave" onclick="clickMe()" data-attr="26">Зачувај Банкомат</button>', 41.886625, 22.500675],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Благој Јанков Мучето&ldquo;</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="27">Зачувај Банкомат</button>', 41.4372778, 22.637333333333334],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>бул. &bdquo;Јане Сандански&ldquo; бр. 26а</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="27">Зачувај Банкомат</button>', 41.9864528, 21.463716666666667],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Даме Груев&ldquo; бр. 7</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="28">Зачувај Банкомат</button>', 41.9949083, 21.427619444444446],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Димитрие Чуповски&ldquo; бр. 1, Рекорд - Центар</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="29">Зачувај Банкомат</button>', 41.9952133651166, 21.43180026294749],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>бул. &bdquo;Партизански одреди&ldquo; бр. 171а</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="30">Зачувај Банкомат</button>', 42.0092, 21.36603888888889],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;16-та Македонска бригада&ldquo; бр. 2/3</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="31">Зачувај Банкомат</button>', 42.0092, 21.36603888888889],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Сава Ковачевиќ&ldquo; бр. 43/1-1</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="32">Зачувај Банкомат</button>', 42.0030361, 21.46018861111111],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Љубљанска&ldquo; бр. 4</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="33">Зачувај Банкомат</button>', 42.00423444026244, 21.392509686191488],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;ЈНА&ldquo; бр. 102</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="34">Зачувај Банкомат</button>', 42.1334917, 21.709519444444442],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Гоце Делчев&ldquo; бр. 38</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="35">Зачувај Банкомат</button>', 41.9760417, 21.717594444444444],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Илинденска&ldquo; бр. 2 б</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="36">Зачувај Банкомат</button>', 41.7167611, 21.782533333333333],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Методија Андонов Ченто&ldquo; бр. 4</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="37">Зачувај Банкомат</button>', 42.0110806, 20.97228611111111],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Илинденска&ldquo; бр. 226</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="38">Зачувај Банкомат</button>', 42.0102528, 20.97423611111111],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Скопски пат&ldquo; бр. 8</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="39">Зачувај Банкомат</button>', 41.9975694, 20.960880555555555],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Иво Лола Рибар&ldquo; бр. 18</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="40">Зачувај Банкомат</button>', 42.008253118818494, 20.976988016532914],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Македонски Просветители&ldquo; бр. 8в</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="41">Зачувај Банкомат</button>', 41.7924611, 20.910016666666664],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Столарска&ldquo; бр. 7</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="42">Зачувај Банкомат</button>', 41.0307194, 21.335644444444444],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Кузман Јосифовски Питу&ldquo; бр. 10</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="43">Зачувај Банкомат</button>', 41.5124722, 20.96325],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;8-ми Септември&ldquo; бр. 1/3</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="44">Зачувај Банкомат</button>', 41.524375, 20.526580555555554],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Јаќим Стојковски&ldquo; бр. 7а</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="45">Зачувај Банкомат</button>', 41.9997617, 22.17921138888889],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Столарска&ldquo; бр. 1</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="46">Зачувај Банкомат</button>', 41.0315693, 21.335511699999984],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Прилепска&ldquo; бр. 42</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="47">Зачувај Банкомат</button>', 41.0328326, 21.34218839999994],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Генерал Васко Карангелески&ldquo; бб</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="48">Зачувај Банкомат</button>', 41.0274049, 21.313922899999966],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Борис Кидрич&ldquo; бб</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="49">Зачувај Банкомат</button>', 41.3481472, 21.556672222222222],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Сремски фронт&ldquo; бр. 26</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="50">Зачувај Банкомат</button>', 41.74927634430862, 22.199424482174322],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Ванчо Прќе&ldquo; бр. 67</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="51">Зачувај Банкомат</button>', 42.1356889, 21.717594444444444],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Пролетерски бригади&ldquo; бр. 43</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="52">Зачувај Банкомат</button>', 41.1808306, 20.67585],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Кеј на Револуцијата&ldquo; бр. 13</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="53">Зачувај Банкомат</button>', 41.91915794703534, 22.410881619379325],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Никола Карев&ldquo; бб</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="54">Зачувај Банкомат</button>', 41.886625, 22.500675],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Благој Јанков Мучето&ldquo; бр. 2</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="55">Зачувај Банкомат</button>', 41.99976179999999, 22.179211399999986],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Илинденска&ldquo; бр. 7</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="56">Зачувај Банкомат</button>', 41.433869964556585, 22.012004753984684],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;22-ри Октомври&ldquo; бб</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="57">Зачувај Банкомат</button>', 41.6357361, 22.46386111111111],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. Благоја Тоска&ldquo; бр. 208/локал бр. 1</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="58">Зачувај Банкомат</button>', 42.008253118818494, 20.976988016532914],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;8-ми Септември&ldquo; бр. 44</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="59">Зачувај Банкомат</button>', 41.7167611, 21.782533333333333],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Народен фронт&ldquo; бр. 19а</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="60">Зачувај Банкомат</button><p>', 41.99369397903403, 21.416239625206913],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Ќемал Сејфула&ldquo; бр. 1/1/4</p><p>Скопје</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="61">Зачувај Банкомат</button>', 42.02030375726329, 21.443228702271426],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Ќемал Сејфула&ldquo; бр. 1/1/4</p><p>Скопје</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="62">Зачувај Банкомат</button><p>', 42.0202392, 21.443179722222222],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Климент Охридски&ldquo; бр. 43</p><button type="button" id="btnSave" onclick="clickMe()" data-attr="63">Зачувај Банкомат</button><p>', 41.1145826546417, 20.80049306805347]


    ];

    L.tileLayer('https://api.mapbox.com/styles/v1/{id}/tiles/{z}/{x}/{y}?access_token=pk.eyJ1IjoiaHJpc3RpamFuIiwiYSI6ImNreGxvcWkzdjA1ZXYyb3A3MHljY3FrM3QifQ.H81GPu4dvu5P_rON5RzJIg', {
        attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
        maxZoom: 18,
        id: 'mapbox/streets-v11',
        tileSize: 512,
        zoomOffset: -1,
        accessToken: 'your.mapbox.access.token'
    }).addTo(map);

    //dodavanje na ekspoziturite na mapata
    for (var i = 0; i < locations.length; i++) {
        marker = new L.marker([locations[i][1], locations[i][2]])
            .bindPopup(locations[i][0])
            .addTo(map);
    }

    function clickMe() {
        var temp = $("#btnSave").attr("data-attr");
        var test = 1;
        if (localStorage.getItem("test") != null) {
            test = localStorage.getItem("test");
        }
        for (var i = 1; i <= locations.length; i++) {

            if (i == temp) {
                localStorage.setItem("podatociZaBankata" + test, locations[i][0]);
                test++;
            }

        }

        localStorage.setItem("test", test);
    }



</script>

