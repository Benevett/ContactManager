 
import { Component, OnInit, OnChanges } from "@angular/core";

import { Http } from '@angular/http';
import { ActivatedRoute } from "@angular/router";
import { Contact } from "./contact.model";
import { ContactService } from "./contact.service";
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
    selector: 'newcontact',
    templateUrl: './newcontact.component.html'
})
export class NewContactComponent implements OnInit {
    ngOnInit(): void {
         
    }
  
    complexForm: FormGroup;
    saved=false;

    constructor(private route: ActivatedRoute, private contactService: ContactService, fb: FormBuilder) {
      
            this.complexForm = fb.group({
                'firstname': '',
                'lastname': '',
                'email': '',
                'mobilenumber': '',
                'homenumber': ''
            });
       
    }

    onSubmit() {
       //grab the updated values from the form 
        const formModel = this.complexForm.value;
        const createContact: Contact = {
            id: "0",
            firstname: formModel.firstname as string,
            surname: formModel.lastname as string,
            email: formModel.email as string,
            mobileNumber: formModel.mobilenumber as string,
            homeNumber: formModel.homenumber as string,
            hasphoto: false,
            base64photo: ''


        };

        this.contactService.create(createContact).subscribe();
        this.saved = true;
      //  console.log(this.saved);
    }

     
     
    
}