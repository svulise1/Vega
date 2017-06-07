import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class VechileService {

    constructor(private http: Http) { }

    getMakes() {
        return this.http.get('api/makes')          
        .map(res => res.json());
    }
    GetFeatures() {
        return this.http.get('api/features')
            .map(res => res.json());
    }

}
