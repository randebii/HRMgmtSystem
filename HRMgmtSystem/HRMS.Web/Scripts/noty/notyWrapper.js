function showNotification(message, type, timeout) {
    if (!timeout) {
        timeout = 5000;
    }
    noty({
        layout: "bottomRight",
        text: message,
        type: type,
        theme: "relax",
        timeout: timeout,
        animation: {
            open: 'animated flipInX',
            close: 'animated lightSpeedOut'
        }
    });
}

function showConfirm(message, onOK, onCancel) {
    noty({
        layout: "center",
        text: message,
        theme: "relax",
        animation: {
            open: 'animated bounceIn',
            close: 'animated bounceOut'
        },
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