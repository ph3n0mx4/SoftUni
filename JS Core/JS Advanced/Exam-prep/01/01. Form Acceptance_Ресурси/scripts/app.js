function acceptance() {
	let company = document.getElementsByTagName(`input`)[0];
	let name = document.getElementsByTagName(`input`)[1];
	let quantity = document.getElementsByTagName(`input`)[2];
	let scrape = document.getElementsByTagName(`input`)[3];
	let addBtn = document.getElementById(`acceptance`);
	let warehouse = document.getElementById(`warehouse`);

	let btnsOOS = warehouse.getElementsByTagName(`button`);
	addBtn.addEventListener(`click`, function () {
		let difference = Number(quantity.value)-Number(scrape.value);

		if(company.value && name.value && quantity.value && scrape.value
			&& !isNaN(quantity.value) && !isNaN(scrape.value) && difference>0){
			let div = document.createElement(`div`);
			let p = document.createElement(`p`);
			let outOfStockBtn = document.createElement(`BUTTON`);
			outOfStockBtn.setAttribute(`type`, `button`);
			outOfStockBtn.innerHTML=`Out of stock`;

			outOfStockBtn.addEventListener(`click`,function () {
				//console.log(`asdasdasd`)
				let divForDelete = outOfStockBtn.parentNode;
				warehouse.removeChild(divForDelete);
			});

			//outOfStockBtn.classList.add(`out`);
			p.textContent=`[${company.value}] ${name.value} - ${difference} pieces`;
			div.appendChild(p);
			div.appendChild(outOfStockBtn);
			warehouse.appendChild(div);
		}

		deleteFields();

	});

	function deleteFields() {
		company.value = ``;
		name.value = ``;
		quantity.value = ``;
		scrape.value = ``;
	}
}