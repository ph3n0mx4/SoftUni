// NOTE: The comment sections inside the index.html file is an example of how suppose to be structured the current elements.
//       - You can use them as an example when you create those elements, to check how they will be displayed, just uncomment them.
//       - Also keep in mind that, the actual skeleton in judge does not have this comment sections. So do not be dependent on them!
//       - Тhey are present in the skeleton just to help you!


// This function will be invoked when the html is loaded. Check the console in the browser or index.html file.
function mySolution(){
	let textArea = document.getElementById(`inputSection`).children[0];
	let username = document.getElementsByTagName(`input`)[0];
	let sendBtn = document.getElementById(`inputSection`).children[1].
		getElementsByTagName(`button`)[0];
	let pendingQuestion = document.getElementById(`pendingQuestions`);//openQuestions
	let openQuestions = document.getElementById(`openQuestions`);//openQuestions

	sendBtn.addEventListener(`click`, function () {
		if(textArea.value!==``){
			let div = document.createElement(`div`);
			div.classList.add(`pendingQuestion`);
			let img = document.createElement(`img`);
			img.src=`./images/user.png`;
			//img.setAttribute(`src`,`./images/user.png`);
			img.setAttribute(`width`,`32`);
			img.setAttribute(`height`,`32`);

			let span = document.createElement(`span`);
			if(username.value===``){
				span.textContent=`Anonymous`;
			}else {
				span.textContent=username.value;
			}

			let p = document.createElement(`p`);
			p.textContent=textArea.value;

			let divChild=document.createElement(`div`);
			divChild.classList.add(`actions`);

			let archiveBtn=document.createElement(`button`);
			archiveBtn.textContent=`Archive`;
			archiveBtn.classList.add(`archive`);
			archiveBtn.addEventListener(`click`,function () {
				let parent=div.parentNode;
				parent.removeChild(div);
			});

			let openBtn=document.createElement(`button`);
			openBtn.textContent=`Open`;
			openBtn.classList.add(`open`);
			openBtn.addEventListener(`click`,function () {
				let parent=div.parentNode;
				parent.removeChild(div);
				divChild.removeChild(archiveBtn);
				divChild.removeChild(openBtn);

				div.classList.remove(`pendingQuestion`);
				div.classList.add(`openQuestion`)
				let replyBtn=document.createElement(`button`);
				replyBtn.classList.add(`reply`);
				replyBtn.textContent=`Reply`;
				divChild.appendChild(replyBtn);

				replyBtn.addEventListener(`click`,function () { //REPLY BUTTON
					if(replyBtn.textContent===`Reply`){
						divChild2.style.display=`block`;
						replyBtn.textContent=`Back`;
					}
					else {
						divChild2.style.display=`none`;
						replyBtn.textContent=`Reply`;
					}

				});

				let divChild2=document.createElement(`div`);
				divChild2.classList.add(`replySection`);
				divChild2.style.display=`none`;

				let input = document.createElement(`input`);
				input.classList.add(`replyInput`);
				input.setAttribute(`type`,`text`);
				input.setAttribute(`placeholder`,`Reply to this question here...`);


				let sendBtn = document.createElement(`button`);
				sendBtn.classList.add(`replyButton`);
				sendBtn.textContent=`Send`;

				sendBtn.addEventListener(`click`,function () { //SEND BUTTON
					if(input.value!==``){
						let li = document.createElement(`li`);
						li.textContent=input.value;
						input.value=``;
						ol.appendChild(li);
					}
				});

				let ol = document.createElement(`ol`);
				ol.classList.add(`reply`);
				ol.setAttribute(`type`,`1`);



				divChild2.appendChild(input);
				divChild2.appendChild(sendBtn);
				divChild2.appendChild(ol);

				div.appendChild(divChild2);
				openQuestions.appendChild(div);
			});


			divChild.appendChild(archiveBtn);
			divChild.appendChild(openBtn);

			div.appendChild(img);
			div.appendChild(span);
			div.appendChild(p);
			div.appendChild(divChild);
			pendingQuestion.appendChild(div);
		}


		textArea.value=``;
		username.value=``;
		/*console.log(textArea.value);
		console.log(username.value===``);*/
	})


}
// To check out your solution, just submit mySolution() function in judge system.
