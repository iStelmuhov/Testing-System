function showSubjectCreateModal() {
    $('#newSubjectModal').modal();
}

function showCategoryEditModal() {
    $("#modalHeader").empty();
    $('#modalHeader').append("<span class=\"glyphicon glyphicon-refresh\"></span> Редактировать категорию");
    $("#modalOkButton").empty();
    $('#modalOkButton').append("<span class=\"glyphicon glyphicon-ok-sign\"></span> Обновить");
    $("#newCategoryModal").modal();
}

function showCategoryCreateModal() {
    $("#modalHeader").empty();
    $('#modalHeader').append("<span class=\"glyphicon glyphicon-bookmark\"></span> Создать новую категорию");
    $("#modalOkButton").empty();
    $('#modalOkButton').append("<span class=\"glyphicon glyphicon-plus-sign\"></span> Создать");
    $("#newCategoryModal").modal();
}

function previewFile(imgId) {
    var preview = document.querySelector('#' + imgId);
    var file = document.querySelector('input[type=file]').files[0];
    var reader = new FileReader();

    reader.onloadend = function () {
        preview.src = reader.result;
    }

    if (file) {
        reader.readAsDataURL(file);
    } else {
        preview.src = "";
    }
}

function colorBG(element, color) {
    element.style.backgroundColor = color;
}

function showDescription(id) {
    //TODO Ajax request info
    $("#categoriesGrid").removeClass("col-sm-12").addClass("col-sm-8");
    $("#aditionalInfoPanel").addClass("col-sm-4");

    var div = document.createElement('div');
    div.className = 'thumbnail caption';

    var closeButton = document.createElement('button');
    closeButton.className = 'btn btn-link pull-right';
    closeButton.onclick = function () { closeDescription() };

    var closeIcon = document.createElement('span');
    closeIcon.className = 'glyphicon glyphicon-remove';

    closeButton.appendChild(closeIcon);
    div.appendChild(closeButton);

    var h3 = document.createElement('h3');
    h3.className = 'text-center';
    h3.appendChild(document.createTextNode("C#"));

    div.appendChild(h3);

    var descriptionP = document.createElement('p');
    descriptionP.appendChild(document.createTextNode("ASP.NET MVC gives you a powerful, patterns-based way to build dynamic websites that enables a clean separation of concerns and gives you full control over markup for enjoyable, agile development."));

    div.appendChild(descriptionP);

    div.appendChild(document.createElement('br'));

    var tbl = document.createElement('table');
    tbl.className = 'table table-hover';
    var tbdy = document.createElement('tbody');

    var thead = document.createElement('thead');
    var thr = document.createElement('tr');

    var th1 = document.createElement('th');
    th1.appendChild(document.createTextNode('Name'));

    var th2 = document.createElement('th');
    th2.appendChild(document.createTextNode('Passed'));

    var th3 = document.createElement('th');
    th3.appendChild(document.createTextNode(''));

    thr.appendChild(th1);
    thr.appendChild(th2);
    thr.appendChild(th3);

    thead.appendChild(thr);
    tbl.appendChild(thead);

    for (var i = 0; i < 4; i++) {
        var tr = document.createElement('tr');

        var td1 = document.createElement('td');
        td1.appendChild(document.createTextNode('Basics of C#'));

        var td2 = document.createElement('td');
        td2.appendChild(document.createTextNode(i + ' of ' + 4));

        var td3 = document.createElement('td');
        var startButton = document.createElement('button');
        startButton.className = 'btn btn-primary';
        startButton.onclick = function () { showTestStartModal() };
        startButton.appendChild(document.createTextNode('Start'));

        var editButton = document.createElement('button');
        editButton.className = 'btn btn-info editButton';
        editButton.onclick = function () { showTestStartModal() };
        var icon = document.createElement('span');
        icon.className = 'glyphicon glyphicon-wrench';
        editButton.appendChild(icon);

        td3.appendChild(startButton);
        td3.appendChild(editButton);

        tr.appendChild(td1);
        tr.appendChild(td2);
        tr.appendChild(td3);

        tbdy.appendChild(tr);
    }
    tbl.appendChild(tbdy);

    var addNewButton = document.createElement('button');
    addNewButton.className = 'btn btn-info btn-block';
    addNewButton.onclick = function () { showSubjectCreateModal() };
    addNewButton.appendChild(document.createTextNode('Добавить новй тест'));

    div.appendChild(tbl);
    div.appendChild(addNewButton);
    $("#aditionalInfoPanel").empty();
    $("#aditionalInfoPanel").append(div);
}

function closeDescription() {
    $("#aditionalInfoPanel").empty();
    $("#categoriesGrid").removeClass("col-sm-8").addClass("col-sm-12");
    $("#aditionalInfoPanel").removeClass("col-sm-4");
}

function showTestStartModal() {

    var divModal = document.createElement('div');
    divModal.className = 'modal fade';
    divModal.setAttribute('id', 'startModal');
    divModal.setAttribute('role', 'dialog');

    var divDialog = document.createElement('div');
    divDialog.className = 'modal-dialog ';

    var divContent = document.createElement('div');
    divContent.className = 'modal-content';

    var divHeader = document.createElement('div');
    divHeader.className = 'modal-header';
    divHeader.setAttribute('style', 'padding:35px 50px;');

    var h3 = document.createElement('h1');
    h3.className = 'text-center';
    h3.appendChild(document.createTextNode("Start Test"));

    divHeader.appendChild(h3);
    divContent.appendChild(divHeader);

    var divBody = document.createElement('div');
    divBody.className = 'modal-body category-modal';

    h3 = document.createElement('h2');
    h3.className = 'text-center';
    h3.appendChild(document.createTextNode("Basics of C#"));

    divBody.appendChild(h3);
    divBody.appendChild(document.createElement('br'));

    var descParagraph = document.createElement('p');
    descParagraph.appendChild(document.createTextNode('W3Schools is optimized for learning, testing, and training. Examples might be simplified to improve reading and basic understanding.'));

    divBody.appendChild(descParagraph);

    var timeDuration = document.createElement('h4');
    timeDuration.appendChild(document.createTextNode('Test duration:' + ' 20' + ' minutes'));
    divBody.appendChild(timeDuration);

    var questionsCount = document.createElement('h4');
    questionsCount.appendChild(document.createTextNode('Questions count:' + ' 20' + ' of ' + '50'));
    divBody.appendChild(questionsCount);

    var startButtonLink = document.createElement('a');
    startButtonLink.className = 'btn btn-primary';
    startButtonLink.setAttribute('role', 'button');
    startButtonLink.setAttribute('href', '@Url.Action("","",new {id=1})');
    startButtonLink.appendChild(document.createTextNode('Start'));

    var closeButton = document.createElement('button');
    closeButton.className = 'btn btn-default text-center';
    closeButton.setAttribute('data-dismiss', 'modal');
    closeButton.appendChild(document.createTextNode('Cancel'));

    divBody.appendChild(startButtonLink);
    divBody.appendChild(closeButton);

    divContent.appendChild(divBody);
    divDialog.appendChild(divContent);
    divModal.appendChild(divDialog);

    document.body.appendChild(divModal);

    $("#startModal").modal();
}

function vibrantColorBG(id) {
    var img = $("#" + id + " img")[0];
    var vibrant = new Vibrant(img, 4, 5);
    var swatches = vibrant.swatches();
    $("#" + id).css("background-color", swatches.Vibrant.getHex());
}
function restoreBG(id) {
    $("#" + id).css("background-color", "#fff");
}
