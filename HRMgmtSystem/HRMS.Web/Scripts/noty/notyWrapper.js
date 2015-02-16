function showNotification(message, type, timeout) {
    if (!timeout) {
        timeout = 5000;
    }
    noty({
        layout: "bottomRight",
        text: message,
        type: type,
        theme: "relax",
        timeout: timeout
    });
}

function showConfirm(message, onOK, onCancel) {
    noty({
        layout: "center",
        text: message,
        theme: "relax",
        buttons: [
		{
		    addClass: 'btn btn-primary', text: 'OK', onClick: function ($noty) {
		        $noty.close();
		        if (onOK) {
		            onOK();
		        }
		    }
		},
		{
		    addClass: 'btn btn-danger', text: 'Cancel', onClick: function ($noty) {
		        $noty.close();
		        if (onCancel) {
		            onCancel();
		        }
		    }
		}
        ]
    })
}