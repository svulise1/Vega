import { Component, OnInit} from '@angular/core';
import { VechileService } from "../../services/vechile.service";
import { ActivatedRoute, Router } from "@angular/router";
import { Observable } from "rxjs/Observable";
import 'rxjs/add/Observable/forkJoin';
import { SaveVechile, Vechile } from "../../Models/Vechile";
import * as  _ from 'underscore';

@Component({
    selector: 'app-vechile-form',
    templateUrl: './vechile-form.component.html',
    styleUrls: ['./vechile-form.component.css'],
    providers: [VechileService]
})
export class VechileFormComponent implements OnInit {
    makes: any[];
    models: any[];
    features: any[];
    vechile: SaveVechile = {
        id: 0,
        makeId: 0,
        modelId: 0,
        isRegistered: false,
        features: [],
        contact: {
            contactName: '',
            contactEmail: '',
            contactPhone:''
        }
    };
   
    constructor(private vechileService: VechileService, private route: ActivatedRoute, private router: Router) {
        route.params.subscribe(p => {
            this.vechile.id = +p['id'];
        });
    }bsc

    ngOnInit() {

        var sources = [this.vechileService.getMakes(),
        this.vechileService.GetFeatures()];

        if (this.vechile.id) {
            sources.push(this.vechileService.GetVechile(this.vechile.id))
        }
        Observable.forkJoin(sources).subscribe(data => {
            this.makes = data[0];
            this.features = data[1];

            if (this.vechile.id) {
                this.setVechile(data[2]);
                this.populate();
            } 
            });
      
    }   

    private setVechile(v:Vechile) {
        this.vechile. id = v.id;
        this.vechile.makeId = v.make.id;
        this.vechile.modelId = v.model.id;
        this.vechile.isRegistered = v.isRegistered;
        this.vechile.contact = v.contact;
        this.vechile.features = _.pluck(v.features, 'id'); 

    }

    onMakeChange() {
        this.populate();
        delete this.vechile.modelId;
    }

    private populate() {
        var selectedmake = this.makes.find(m => m.id == this.vechile.makeId);
        this.models = selectedmake ? selectedmake.models : [];
    }
    onFeatureToggle(featureId, $event) {
        if ($event.target.checked) {
            this.vechile.features.push(featureId);
        }

        else {
            var removedfeature = this.vechile.features.indexOf(featureId);
            this.vechile.features.splice(removedfeature, 1);
        }
    }
    Submit() {
        if (this.vechile.id) {
            this.vechileService.update(this.vechile).subscribe(x => console.log(x));

        }
        else
        this.vechileService.Create(this.vechile).subscribe(m => console.log(m));

    }

    delete() {
        if (confirm("Are You Sure you want to delete")) {
            this.vechileService.delete(this.vechile.id).subscribe(x => this.router.navigate(['/home']));
        }
    }
}