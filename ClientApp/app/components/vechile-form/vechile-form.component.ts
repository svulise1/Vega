import { Component, OnInit } from '@angular/core';
import { VechileService } from "../../services/vechile.service";

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
    vechile: any = {
        features:[]
    };
    constructor(private vechileService: VechileService) { }

  ngOnInit() {
      this.vechileService.getMakes().subscribe(makes => this.makes = makes);
      this.vechileService.GetFeatures().subscribe(features => this.features = features);
  }
  onMakeChange() {
      var selectedmake = this.makes.find(m => m.id == this.vechile.makeId);
      this.models = selectedmake ? selectedmake.models :[];
      delete this.vechile.modelId;
  }

  onFeatureToggle(featureId, $event)
  {
      if ($event.target.checked) {
          this.vechile.features.push(featureId);
      }
      
      else {
          var removedfeature = this.vechile.features.indexOf(featureId);
          this.vechile.features.splice(removedfeature, 1);
      }
  }

}
