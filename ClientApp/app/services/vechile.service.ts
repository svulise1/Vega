import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class VechileService {

    constructor(private http: Http) {
        this.http = http;}

    getMakes() {
        return this.http.get('http://localhost:5000/api/makes')          
        .map(res => res.json());
    }
    GetFeatures() {
        return this.http.get('http://localhost:5000/api/features')
            .map(res => res.json());
    }

    Create(vechile) {
        return this.http.post('http://localhost:5000/api/vechiles/',vechile)
            .map(res => res.json());
    }

    GetVechile(id) {
        return this.http.get('http://localhost:5000/api/vechiles/' + id)
            .map(res => res.json());

    }

    update(vechile) {
        return this.http.put('http://localhost:5000/api/vechiles/' + vechile.id,vechile)
            .map(res => res.json());
    }

    delete(id) {
        return this.http.delete('http://localhost:5000/api/vechiles/' + id)
            .map(res => res.json());
    }

}
