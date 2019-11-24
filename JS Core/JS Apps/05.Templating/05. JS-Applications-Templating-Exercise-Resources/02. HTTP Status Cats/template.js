(() => {
     renderCatTemplate();

     [...document.getElementsByClassName(`showBtn`)]
         .forEach(btn=>{
              btn.addEventListener(`click`,function ({target}) {
                   if(btn.textContent===`Show status code`){
                        btn.textContent=`Hide status code`;
                   }
                   else {
                        btn.textContent=`Show status code`
                   }
                   let card = target.parentNode;
                   let status = card.getElementsByClassName(`status`)[0];
                   status.style.display=status.style.display
                       ?``
                       :`none`;
              })
         });

     function renderCatTemplate() {
          let template=document.getElementById(`cat-template`).innerHTML;
          let compiled = Handlebars.compile(template);
          let rendered =compiled({cats});
          document.getElementById(`allCats`).innerHTML=rendered;
     }
 
})();
