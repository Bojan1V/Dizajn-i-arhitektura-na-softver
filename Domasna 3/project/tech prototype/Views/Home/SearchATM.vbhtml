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
        height: 700px;
    }

    .leaflet-popup-content img {
        margin-bottom: 10px;
        margin-left: 20%;
        width: 100px !important;
        height: 100px !important;
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
    <h3>Пребарувајте банкомати така што ќе го внесете градот и ќе ги добиете сите достапни банкомати за истиот град</h3>
</div>


@* dropdown pole, za lista na gradovi *@
<h5>
    Изберете град: <select name="vrsta" class="grad_selection" style="width: 100%">
        <option value="1">Скопје</option>
        <option value="2">Берово</option>
        <option value="3">Битола</option>
        <option value="4">Богданци</option>
        <option value="5">Валандово</option>
        <option value="6">Велес</option>
        <option value="7">Виница</option>
        <option value="8">Гевгелија</option>
        <option value="9">Гостивар</option>
        <option value="11">Делчево</option>
        <option value="12">Демир Капија</option>
        <option value="13">Демир Хисар</option>
        <option value="14">Кавадарци</option>
        <option value="15">Кичево</option>
        <option value="16">Кочани</option>
        <option value="17">Кратово</option>
        <option value="18">Крива Паланка</option>
        <option value="19">Крушево</option>
        <option value="20">Куманово</option>
        <option value="21">Македонски Брод</option>
        <option value="23">Неготино</option>
        <option value="24">Охрид</option>
        <option value="26">Прилеп</option>
        <option value="27">Пробиштип</option>
        <option value="28">Радовиш</option>
        <option value="29">Ресен</option>
        <option value="30">Свети Николе</option>
        <option value="31">Струга</option>
        <option value="32">Струмица</option>
        <option value="33">Тетово</option>
        <option value="34">Штип</option>
        <option value="35">Дојран</option>
    </select>
</h5>

@* prikaz na mapa *@
<div id="map"></div>

<script type="text/javascript">
    $(document).ready(function () {

        $('.grad_selection').change(function () {
            var selectedValue = parseInt(jQuery(this).val());

            switch (selectedValue) {
                case 1:
                    map.setView([41.9933528, 21.41643333333333], 12);
                    break;
                case 2:
                    map.setView([41.7061, 22.8552], 12);
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
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>бул. &bdquo;Јане Сандански&ldquo; бр. 26, влез 2, локал 4</p>', 41.9864528, 21.46371667],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p style="margin-left: 35px;">ул. "adresa" бр. 43/1-1</p> <p style="margin-left: 35px;">02/32 47 000 лок. 000</p><p style="margin-left: 35px;">понеделник - петок од 8:30 до 16:30 часот<br />сабота од 8:30 до 16:30 часот</p><p style="margin-left: 35px;"><strong>Раководител:</strong> Име Презиме</p><p style="margin-left: 35px;">02/32 47 000 лок. 000</p><p style="margin-left: 35px;"><a href="mailto:ime.prezime@ttk.com.mk">ime.prezime@ttk.com.mk</a></p>', 41.9949083, 21.42761944],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p style="margin-left: 35px;">ул. "adresa" бр. 43/1-1</p>', 41.9760417, 21.44379444],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>бул. &bdquo;Партизански одреди&ldquo; бр. 171а</p><p>контакт телефон: 02/32 47 000 лок. 552</p><p>работно време: од понеделник до петок од 8:00 до 16:00 часот</p><p>раководител: Натка Ќирова Јонузи</p><p>контакт телефон: 02/32 47 000 лок. 551</p><p>е-пошта: natka.kirova@ttk.com.mk.</p>', 42.0092, 21.36603889],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;16-та Македонска бригада&ldquo; бр. 2/3</p><p>контакт телефон: 02/32 47 000 лок. 562</p><p>работно време: од понеделник до петок од 8:00 до 16:00 часот</p><p>раководител: Маја Милкова</p><p>контакт телефон: 02/32 47 000 лок. 561</p><p>е-пошта: maja.milkova@ttk.com.mk.</p>', 42.0030361, 21.46018861],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>бул. &bdquo;Александар Македонски&ldquo; бр. 26 б, контакт телефон: 02/32 47 000 лок. 591, 592, работно време: понеделник - петок од 8:00 до 18:00 часот, сабота од 9:00 до 13:00 часот, Одговорно лице: Зоран Благоев, контакт телефон: 02/32 47 000 лок. 501, е-пошта: zoran.blagoev@ttk.com.mk.</p>', 42.0026333, 21.47454722],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Гоце Делчев&ldquo; бр. 38, контакт телефон: 02/32 47 000 лок. 604, 605, работно време: понеделник - петок од 8:00 до 16:00 часот, сабота од 9:00 до 13:00 часот, Директор: Далибор Арсовски, контакт телефон: 02/32 47 000 лок. 606, е-пошта: dalibor.arsovski@ttk.com.mk.</p>', 42.1356889, 21.71759444],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;ЈНА&ldquo; бр. 102, контакт телефон: 02/32 47 000 лок. 611, 612, работно време: понеделник - петок од 8:30 до 16:30 часот, Одговорно лице: Далибор Арсовски, контакт телефон: 02/32 47 000 лок. 606, е-пошта: dalibor.arsovski@ttk.com.mk.</p>', 42.1334917, 21.70951944],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;8-ми Септември&ldquo; бр. 44</p><p>контакт телефон: 02/32 47 000 лок. 621</p><p>работно време: од понеделник до петок, од 8:00 до 16:00 часот</p><p>Раководител: Светлана Дафинчевска</p><p>е-пошта: svetlana.dafincevska@ttk.com.mk</p>', 41.7167611, 21.78253333],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>бул. &bdquo;Илинденска&ldquo; бр. 2 б контакт телефон: 02/32 47 000 лок. 208 работно време: понеделник - петок од 8:00 до 18:00, сабота 9:00 до 13:00 часот Директор: Азби Махмуди контакт телефон: 02/32 47 000 лок. 201 е-пошта: azbi.mahmudi@ttk.com.mk</p>', 42.0110806, 20.97228611],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Илирија&ldquo; бр. 40 контакт телефон: 02/32 47 000 лок. 242, 244 работно време: понеделник - петок од 8:00 до 16:00 часот Одговорно лице: Азби Махмуди контакт телефон: 02/32 47 000 лок. 201 е-пошта: azbi.mahmudi@ttk.com.mk</p>', 42.0091667, 20.97178333],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Методиј Андонов Ченто&ldquo; бр. 4</p><p>контакт телефон: 02/32 47 000 лок. 252</p><p>работно време: од понеделник до петок, од 8:00 до 16:00 часот</p><p>одговорно лице: Азби Махмуди</p><p>е-пошта: azbi.mahmudi@ttk.com.mk</p>', 42.0102528, 20.97423611],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Илинденска&ldquo; бр. 226 контакт телефон: 02/32 47 000 лок. 271 работно време: понеделник - петок од 9:00 до 17:00 часот Раководител: Агим Идризи контакт телефон: 02/32 47 000 лок. 272 е-пошта: agim.idrizi@ttk.com.mk</p>', 41.9975694, 20.96088056],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Скопски пат&ldquo; бр. 8 контакт телефон: 02/32 47 000 лок. 261, 262 работно време: понеделник - петок од 10:00 до 17:00 часот, сабота од 11:00 до 16:00 часот Одговорно лице: Агим Идризи контакт телефон: 02/32 47 000 лок. 272 е-пошта: agim.idrizi@ttk.com.mk</p>', 42.0040917, 20.98945556],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Иво Лола Рибар&ldquo; бр. 18</p><p>контакт телефон: 02/32 47 000 лок. 282</p><p>работно време: од понеделник до петок, од 8:30 до 16:30 часот</p><p>раководител: Озал Сарач</p><p>е-пошта: ozal.sarac@ttk.com.mk</p>', 41.7924611, 20.910016666666664],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Македонски просветители&ldquo; бр. 8в контакт телефон: 02/32 47 000 лок. 632 работно време: понеделник - петок од 8:00 до 16:00 часот, сабота од 9:00 до 16:00 часот Директор: Билјана Азеска Толеска контакт телефон: 02/32 47 000 лок. 631 е-пошта: biljana.azeska@ttk.com.mk</p>', 41.1155528, 20.801355555555556],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Пролетерски бригади&ldquo; бр. 43 контакт телефон: 02/32 47 000 лок. 642 работно време: понеделник - петок од 8:00 до 16:00 часот Раководител: Горан Чакар контакт телефон: 02/32 47 000 лок. 641 е-пошта: goran.cakar@ttk.com.mk</p>', 41.180748841584986, 20.67597807548043],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Кузман Јосифовски Питу&ldquo; бр. 10 контакт телефон: 02/32 47 000 лок. 652 работно време: понеделник - петок од 8:00 до 16:00 часот Раководител: Драгана Матеска контакт телефон: 02/32 47 000 лок. 651 е-пошта: dragana.mateska@ttk.com.mk</p>', 41.5124722, 20.96325],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>бул. &bdquo;8-ми Септември&ldquo; бр. 1/3 контакт телефон: 02/32 47 000 лок. 662 работно време: понеделник - петок од 8:00 до 16:00 часот Раководител: Фатмир Окше контакт телефон: 02/32 47 000 лок. 661 е-пошта: fatmir.okse@ttk.com.mk</p>', 41.524301704326575, 20.526651634094378],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Столарска&ldquo; бр. 7 контакт телефон: 02/32 47 000 лок. 303, 304 работно време: понеделник - петок од 8:00 до 18:00 часот, сабота од 9:00 до 13:00 часот Директор: Бисера Димитрова контакт телефон: 02/32 47 000 лок. 302 е-пошта: bisera.dimitrova@ttk.com.mk</p>', 41.0307194, 21.335644444444444],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;1-ви Мај&ldquo; бр. 204/4</p><p>контакт телефон: 02/32 47 000 лок. 323, 324</p><p>работно време: понеделник - петок од 8:00 до 16:00 часот</p><p>сабота од 9:00 до 13:00 часот</p><p>раководител: Сотир Николовски</p><p>контакт телефон: 02/32 47 000 лок. 303</p><p>е-пошта: sotir.nikolovski@ttk.com.mk</p>', 41.0312694, 21.336105555555555],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Борис Кидрич&ldquo; бб</p><p>контакт телефон: 02/32 47 000 лок. 352</p><p>работно време: од понеделник до петок</p><p>од 8:00 до 16:00 часот</p><p>раководител: Наташа Апостолоска</p><p>е-пошта: natasa.apostoloska@ttk.com.mk</p>', 41.3481472, 21.556672222222222],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Ванчо Прќе&ldquo; бр. 67 контакт телефон: 02/32 47 000 лок. 704 работно време: понеделник - петок од 8:00 до 16:00 часот, сабота од 9:00 до 13:00 часот Директор: Благој Димитров контакт телефон: 02/32 47 000 лок. 705 е-пошта: blagoj.dimitrov@ttk.com.mk</p>', 42.1356889, 21.717594444444444],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Кеј на Револуцијата&ldquo; бр. 13 контакт телефон: 02/32 47 000 лок.721 работно време: понеделник - петок од 8:00 до 16:00 часот Раководител: Ангела Ефтимова контакт телефон: 02/32 47 000 лок. 722 е-пошта: angela.eftimova@ttk.com.mk</p>', 41.91915794703534, 22.410881619379325],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Никола Карев&ldquo; бб контакт телефон: 02/32 47 000 лок. 732 работно време: понеделник - петок од 8:00 до 16:00 часот Раководител: Ангела Ефтимова контакт телефон: 02/32 47 000 лок.722 е-пошта: angela.eftimova@ttk.com.mk</p>', 41.886625, 22.500675],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Благој Јанков Мучето&ldquo; бр. 2 контакт телефон: 02/32 47 000 лок. 671 работно време: понеделник - петок од 8:00 до 16:00 часот, сабота од 9:00 до 13:00 часот Директор: Мирјана Грамбозова контакт телефон: 02/32 47 000 лок. 673 е-пошта: mirjana.grambozova@ttk.com.mk</p>', 41.4372778, 22.637333333333334],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>бул. &bdquo;Јане Сандански&ldquo; бр. 26а</p><p>контакт телефон: 02/32 47 000 лок. 524,525</p><p>работно време: од понеделник до петок од 8:00 до 16:00 часот</p><p>сабота од 9:00 до 13:00 часот</p><p>раководител: Марија Андоновска</p><p>е-пошта: marija.andonovska@ttk.com.mk</p>', 41.9864528, 21.463716666666667],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Даме Груев&ldquo; бр. 7</p>', 41.9949083, 21.427619444444446],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Димитрие Чуповски&ldquo; бр. 1, Рекорд - Центар</p>', 41.9952133651166, 21.43180026294749],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>бул. &bdquo;Партизански одреди&ldquo; бр. 171а</p>', 42.0092, 21.36603888888889],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;16-та Македонска бригада&ldquo; бр. 2/3</p>', 42.0092, 21.36603888888889],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Сава Ковачевиќ&ldquo; бр. 43/1-1</p>', 42.0030361, 21.46018861111111],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Љубљанска&ldquo; бр. 4</p>', 42.00423444026244, 21.392509686191488],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;ЈНА&ldquo; бр. 102</p>', 42.1334917, 21.709519444444442],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Гоце Делчев&ldquo; бр. 38</p>', 41.9760417, 21.717594444444444],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Илинденска&ldquo; бр. 2 б</p>', 41.7167611, 21.782533333333333],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Методија Андонов Ченто&ldquo; бр. 4</p>', 42.0110806, 20.97228611111111],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Илинденска&ldquo; бр. 226</p>', 42.0102528, 20.97423611111111],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Скопски пат&ldquo; бр. 8</p>', 41.9975694, 20.960880555555555],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Иво Лола Рибар&ldquo; бр. 18</p>', 42.008253118818494, 20.976988016532914],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Македонски Просветители&ldquo; бр. 8в</p>', 41.7924611, 20.910016666666664],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Столарска&ldquo; бр. 7</p>', 41.0307194, 21.335644444444444],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Кузман Јосифовски Питу&ldquo; бр. 10</p>', 41.5124722, 20.96325],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;8-ми Септември&ldquo; бр. 1/3</p>', 41.524375, 20.526580555555554],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Јаќим Стојковски&ldquo; бр. 7а</p>', 41.9997617, 22.17921138888889],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Столарска&ldquo; бр. 1</p>', 41.0315693, 21.335511699999984],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Прилепска&ldquo; бр. 42</p>', 41.0328326, 21.34218839999994],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Генерал Васко Карангелески&ldquo; бб</p>', 41.0274049, 21.313922899999966],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Борис Кидрич&ldquo; бб</p>', 41.3481472, 21.556672222222222],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Сремски фронт&ldquo; бр. 26</p>', 41.74927634430862, 22.199424482174322],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Ванчо Прќе&ldquo; бр. 67</p>', 42.1356889, 21.717594444444444],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Пролетерски бригади&ldquo; бр. 43</p>', 41.1808306, 20.67585],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Кеј на Револуцијата&ldquo; бр. 13</p>', 41.91915794703534, 22.410881619379325],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Никола Карев&ldquo; бб</p>', 41.886625, 22.500675],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Благој Јанков Мучето&ldquo; бр. 2</p>', 41.99976179999999, 22.179211399999986],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Илинденска&ldquo; бр. 7</p>', 41.433869964556585, 22.012004753984684],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;22-ри Октомври&ldquo; бб</p>', 41.6357361, 22.46386111111111],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. Благоја Тоска&ldquo; бр. 208/локал бр. 1</p>', 42.008253118818494, 20.976988016532914],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;8-ми Септември&ldquo; бр. 44</p>', 41.7167611, 21.782533333333333],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Народен фронт&ldquo; бр. 19а</p><p>контакт телефон: 02/32 47 000 лок. 508, 509</p><p>работно време: од понеделник до петок од 8:00 до 17:00 часот</p><p>сабота од 9:00 до 13:00 часот</p><p>директор: Зоран Благоев</p><p>е-пошта: zoran.blagoev@ttk.com.mk</p>', 41.99369397903403, 21.416239625206913],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Ќемал Сејфула&ldquo; бр. 1/1/4</p><p>Скопје</p>', 42.02030375726329, 21.443228702271426],
        ['<img src="/images/atm.png" style="margin-bottom:10px;margin-left: 20%; width: 50%;height: 100px;">  <p>ул. &bdquo;Ќемал Сејфула&ldquo; бр. 1/1/4</p><p>Скопје</p>	', 42.0202392, 21.443179722222222],
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

