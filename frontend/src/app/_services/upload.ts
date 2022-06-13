import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";

@Injectable({
    providedIn: 'root'
})

export class UploadService {

    private uploadUrl = `${environment.apiUrl}/Upload`;

    constructor(private http: HttpClient){       
    }

    upload(formData): Observable<any> {
        return this.http.post(this.uploadUrl, formData, {reportProgress: true, observe: 'events'});
    }
}