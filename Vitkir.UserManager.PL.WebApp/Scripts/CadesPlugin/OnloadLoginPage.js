(function(){
	let loading = document.getElementById("loading");

	// ожидание загрузки плагина
	window["cadesplugin"].then(() => {

		document.getElementById("myList").removeChild(loading);
		let loadingCertList = document.createTextNode("Идет загрузка сертификатов...");
		document.getElementById("myList").appendChild(loadingCertList);

		// ожидание загрузки сертификатов
		window["FillCertList_NPAPI"]().then(
			(certList) => {

				console.log(JSON.stringify(certList, null, 4));
				document.getElementById("myList").removeChild(loadingCertList);

				certList.forEach((cert) => {
					let text = document.createTextNode(cert.text);
					let listItem = document.createElement('option')
					listItem.innerHTML = cert.text
					document.getElementById("CertListBox").appendChild(listItem);
				});
			},
			(error) => {

				document.getElementById("myList").removeChild(loadingCertList);
				let myError = document.createTextNode("Обнаружены ошибки, смотри в логах");
				document.getElementById("myError").appendChild(myError);


				console.error(error);
			}
		).catch(function (e) {
			console.error(e);
			let myError = document.createTextNode("Обнаружены ошибки, смотри в логах");
			document.getElementById("myError").appendChild(myError);
		});

	}, (error) => {

		console.error(error);
		document.getElementById("myList").removeChild(loading);
		let myError = document.createTextNode("Обнаружены ошибки, смотри в логах");
		document.getElementById("myError").appendChild(myError);

	});
}());