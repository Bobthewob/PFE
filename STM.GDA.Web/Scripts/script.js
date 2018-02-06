// url: controller url
// data: data to send to the controller
// dataType: if dataType is null, default: Intelligent Guess (xml, json, script, or html)
function CallController(url, data, dataType) {
    var httpMethod = 'post';
    if (!data) { httpMethod = 'get'; }
    return $.ajax(
        {
            url: url,
            cache: false,
            type: httpMethod,
            data: JSON.stringify(data),
            dataType: dataType,
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
        CallController(url, data, 'json');
    }
}

// control: Control that containts options tags
// Returns the selected items
function getSelectedItems(control) {
    var selectedValues = $("#" + control + " option:selected").toArray();
    var selectedItems = [];

    selectedValues.forEach(function (item) {
        selectedItems.push({ Id: item.value, Nom: item.text })
    });

    return selectedItems;
}

// control: Control that containts options tags
// Returns all the items in the control
function getAllItems(control) {
    var selectedValues = $("#" + control + " option").toArray();
    var selectedItems = [];

    selectedValues.forEach(function (item) {
        selectedItems.push({ Id: item.value, Nom: item.text })
    });

    return selectedItems;
}

//https://stackoverflow.com/questions/7385246/allow-new-values-with-chosen-js-multiple-select
function chosenMultiselectCustomAdd(controlId) {
    $("#" + controlId).parent().find('.chosen-container .search-field input[type=text]').keydown(
        function (evt) {
            var stroke, _ref, target, list;
            // get keycode
            stroke = (_ref = evt.which) != null ? _ref : evt.keyCode;
            // If enter or tab key
            if (stroke === 9 || stroke === 13) {
                target = $(evt.target);
                // get the list of current options
                chosenList = target.parents('.chosen-container').find('.chosen-choices li.search-choice > span').map(function () { return $(this).text(); }).get();
                // get the list of matches from the existing drop-down
                matchList = target.parents('.chosen-container').find('.chosen-results li').map(function () { return $(this).text(); }).get();
                // highlighted option
                highlightedList = target.parents('.chosen-container').find('.chosen-results li.highlighted').map(function () { return $(this).text(); }).get();
                // Get the value which the user has typed in
                var newString = $.trim(target.val());
                // if the option does not exists, and the text doesn't exactly match an existing option, and there is not an option highlighted in the list
                if ($.inArray(newString, matchList) < 0 && $.inArray(newString, chosenList) < 0 && highlightedList.length == 0) {
                    // Create a new option and add it to the list (but don't make it selected)
                    var newOption = '<option value="' + 0 + '">' + newString + '</option>';
                    $("#" + controlId).prepend(newOption);
                    // trigger the update event
                    $("#" + controlId).trigger("chosen:updated");
                    // tell chosen to close the list box
                    $("#" + controlId).trigger("chosen:close");
                    return true;
                }
                // otherwise, just let the event bubble up
                return true;
            }
        }
    )
};