import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { ContactsComponent } from './components/contacts/contacts.component';
import { EditContactComponent } from './components/contacts/editcontact.component';
import { NewContactComponent } from './components/contacts/newcontact.component';
import { ContactService } from "./components/contacts/contact.service";



@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        ContactsComponent,
        EditContactComponent,
        NewContactComponent
    ],
    providers: [
        ContactService
    ],

    imports: [
        CommonModule,
        HttpModule,
        FormsModule, ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'contacts', component: ContactsComponent },
            { path: "contacts/:id", component: EditContactComponent },
            { path: 'newcontact', component: NewContactComponent },

            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
