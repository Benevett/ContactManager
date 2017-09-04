 
import { Component, OnInit, OnChanges, ViewChild, ElementRef } from "@angular/core";

import { Http } from '@angular/http';
import { ActivatedRoute } from "@angular/router";
import { Contact } from "./contact.model";
import { ContactService } from "./contact.service";
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Routes, Router } from '@angular/router';

@Component({
    selector: 'editcontact',
    templateUrl: './editcontact.component.html'
})
export class EditContactComponent implements OnInit {
    [x: string]: any;

    ngOnInit(): void {

    }
    @ViewChild("fileInput") fileInput: any;
    @ViewChild('imgRef') img: ElementRef;

    contact: Contact;
    complexForm: FormGroup;
    saved = false;


    addFile(): void {
        let fi = this.fileInput.nativeElement;
        if (fi.files && fi.files[0]) {
            let fileToUpload = fi.files[0];
            this.contactService
                .upload(fileToUpload, Number(this.contact.id))
                .subscribe(res => {
                    console.log(res);
                    this.reloadContact();
                });
        }
    }

    deleteclicked(event: any) {
        this.contactService
            .delete(Number(this.contact.id))
            .subscribe();
    }   
                
    

    constructor(private route: ActivatedRoute, private router: Router, private contactService: ContactService, fb: FormBuilder) {
        const id = +this.route.snapshot.params["id"];
        console.log(id);

        contactService.get(id).subscribe(result => {
            this.contact = result as Contact;
            this.contact.id = String(id);

            console.log(this.contact);

            this.complexForm = fb.group({
                'firstname': '',
                'lastname': '',
                'email': '',
                'mobilenumber': '',
                'homenumber': ''
            });

            this.complexForm.patchValue({
                firstname: this.contact.firstname,
                lastname: this.contact.surname,
                email: this.contact.email,
                mobilenumber: this.contact.mobileNumber,
                homenumber: this.contact.homeNumber
            });

        });


    }

    reloadContact() {
        const id = +this.route.snapshot.params["id"];
        console.log(id);

        this.contactService.get(id).subscribe(result => {
            this.contact = result as Contact;
            this.contact.id = String(id);
        });
    }

    onSubmit() {
       //grab the updated values from the form 
        const formModel = this.complexForm.value;
        const saveContact: Contact = {
            id: this.contact.id,
            firstname: formModel.firstname as string,
            surname: formModel.lastname as string,
            email: formModel.email as string,
            mobileNumber: formModel.mobilenumber as string,
            homeNumber: formModel.homenumber as string,
            hasphoto: this.contact.hasphoto,
            base64photo: this.contact.base64photo
            
        };

        this.contactService.update(saveContact).subscribe((l: any) => {        
        //    return this.router.navigate(['contacts']);
        //    this.contact = saveContact;
         });

        this.saved = true;
        
    }

     
     
    
}