import { Component, OnInit } from '@angular/core';
import { Vechile, KeyValuePair } from "../../Models/Vechile";
import { VechileService } from "../../services/vechile.service";

@Component({
  selector: 'app-vechile-list',
  templateUrl: './vechile-list.component.html',
  styleUrls: ['./vechile-list.component.css'],
  providers: [VechileService]
})
export class VechileListComponent implements OnInit {

    vechiles: Vechile[];
    allVechiles: Vechile[];
    makes: KeyValuePair[];
    filter: any= {};
  constructor(private vechileservice :VechileService) { }

  ngOnInit() {
      this.vechileservice.GetVechiles().subscribe(vechiles => this.vechiles = this.allVechiles= vechiles);
      this.vechileservice.getMakes().subscribe(makes => this.makes = makes);
  }

  private onFilterChange() {
      var vechiles = this.allVechiles;
      if (this.filter.makeId)
        vechiles=  vechiles.filter( v=>v.make.id == this.filter.makeId);
      this.vechiles = vechiles;
  }

  resetFilter() {
      this.filter = {};
      this.onFilterChange();
  }

}
