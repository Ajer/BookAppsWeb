$(document).ready(function () {
    $('#theBtn').click(function () {
        var dd = (document.getElementById('srchDropDown').value).trim();
        var casecb = document.getElementById('caseChBox').checked;

        var srch = (document.getElementById('srchField').value).trim();


        var urlStr = '/api/Search';

        if (dd == 'title')
        {
            if (casecb)
            {
                urlStr = urlStr + '?titleSrchStr=' + encodeURIComponent(srch) + '&caseSens=true'
            }
            else {
                urlStr = urlStr + '?titleSrchStr=' + encodeURIComponent(srch);
            }
        }
        else if (dd == 'author')
        {
            if (casecb)
            {
                urlStr = urlStr + '?authSrchStr=' + encodeURIComponent(srch) + '&caseSens=true'
            }
            else {
                urlStr = urlStr + '?authSrchStr=' + encodeURIComponent(srch);
            }      
        }
        else if (dd == 'id')
        {
            if (casecb)
            {
                urlStr = urlStr + '?idSrchStr=' + encodeURIComponent(srch) + '&caseSens=true'
            }
            else {
                urlStr = urlStr + '?idSrchStr=' + encodeURIComponent(srch);
            }
            
        }

        $.ajax({
            type: 'GET',
            url: urlStr,
            dataType: 'json',
            contentType: 'application/json',
            success: function (result) {
                var s = '';
                for (var i = 0; i < result.length; i++) {
                    s = s +
                        "<br/>ID: " +
                        result[i].Id +
                        "<br/>Title: " +
                        result[i].Title +
                        "<br/>Author: " +
                        result[i].Author +
                        "<br/>Genre: " +
                        result[i].Genre +
                        "<br/>Price: " +
                        result[i].Price + " USD" +
                        "<br/>Publish_Date: " +
                        result[i].Publish_Date +
                        "<br/>Descr: " +
                        result[i].Description +
                        "<br/>====================================================<br/>";
                }
               
                $('#resultcount').html('The search found ' + result.length + ' results<br/>');

                $('#srchresult').empty();
                $('#srchresult').append(s); //html(s);
            }
        });
    });
});