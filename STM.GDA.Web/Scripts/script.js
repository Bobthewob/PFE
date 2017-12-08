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