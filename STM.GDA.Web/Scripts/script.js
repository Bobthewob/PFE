// url: controller url
// data: data to send to the controller
// dataType: if dataType is null, default: Intelligent Guess (xml, json, script, or html)
function CallController(url, data, context) {
    var httpMethod = 'post';
    if (!data) { httpMethod = 'get'; }
    return $.ajax(
        {
            url: url,
            context: context,
            cache: false,
            type: httpMethod,
            data: JSON.stringify(data),
            contentType: 'application/json',
            success: function (result) {
                var isRedirect = false;
                try {
                    isRedirect = result.isRedirect;
                }
                finally {
                    if (isRedirect) {
                        window.location.href = result.redirectUrl;
                    }
                }
            }
        }
    );
}

// url: controller url
// data: data to send to the controller
function Redirect(url, data) {
    if (!data) {
        window.location.href = url;
    }
    else {
        CallController(url, data);
    }
}

// control: Control that containts options tags
// Returns the selected items
function getSelectedItems(control) {
    var selectedValues = $("#" + control + " option:selected").toArray();
    var selectedItems = [];

    selectedValues.forEach(function (item) {
        selectedItems.push({ Id: item.value, Nom: item.text });
    });

    return selectedItems;
}

// control: Control that containts options tags
// Returns all the items in the control
function getAllItems(control) {
    var Values = $("#" + control + " option").toArray();
    var AllItems = [];

    Values.forEach(function (item) {
        AllItems.push({ Id: item.value, Nom: item.text });
    });

    return AllItems;
}

// control: Control that contains options tags
// Returns all the text items in the control
function getSelectizeOptions(selectize) {
    var values = selectize.options;
    var allTextItems = [];

    Object.keys(values).forEach(function (key) {
        allTextItems.push(values[key].text);
    });

    return allTextItems;
}

//Uses the base selectizeAdd method but prevents duplicate values based on text input
function selectizeAdd(input, control) {
    var selectize = $('#' + control)[0].selectize;
    var controlItems = getSelectizeOptions(selectize);

    if (!controlItems.includes(input)) {
        return {
            value: input,
            text: input
        };
    }
    else {
        selectize.setTextboxValue('');
        return false;
    }
}