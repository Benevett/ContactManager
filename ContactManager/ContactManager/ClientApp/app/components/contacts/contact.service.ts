import { Contact } from "./contact.model";
import { Injectable ,Inject} from "@angular/core";
import { Http, Headers, Response } from "@angular/http";
import "rxjs/add/operator/toPromise"; 
import { Observable } from "rxjs/Observable";
import 'rxjs/add/operator/map';

@Injectable()
export class ContactService {
    public contacts: Contact[];
    private baseUrl: string;

    constructor(private http: Http, @Inject('BASE_URL') url: string) {
        this.baseUrl = url;

    }

    list(): any {
        return this.http.get(this.baseUrl + 'api/Contacts').subscribe(result => {
            this.contacts = result.json() as Contact[];
        }, error => console.error(error));

    }

    get(id: number): Observable<Contact> {     
        return this.http.get(this.baseUrl + 'api/Contacts/' + id)
            .map(response => response.json());
    
    }   

    update(contact: Contact): any {
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');

        return this.http
            .put(this.baseUrl + 'api/Contacts/' + contact.id, JSON.stringify(contact), { headers: headers } )
            .map(res => res.json());

    }

    create(contact: Contact): any {
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');

        return this.http
            .post(this.baseUrl + 'api/Contacts/', JSON.stringify(contact), { headers: headers })
            .map(res => res.json());

    }

    upload(fileToUpload: any,id:number) {
        let input = new FormData();
        input.append("file", fileToUpload,String(id)); // use the id as the filename
        return this.http
            .post(this.baseUrl+"api/Contacts/upload", input);
    }
    
    delete(id: number) {
        return this.http
            .delete(this.baseUrl + "api/Contacts/"+id);
    }

}