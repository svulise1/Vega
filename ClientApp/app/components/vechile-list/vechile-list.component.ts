import { Component, OnInit } from '@angular/core';
import { Vechile } from "../../Models/Vechile";
import { VechileService } from "../../services/vechile.service";

@Component({
  selector: 'app-vechile-list',
  templateUrl: './vechile-list.component.html',
  styleUrls: ['./vechile-list.component.css'],
  providers: [VechileService]
})
export class VechileListComponent implements OnInit {

    vechiles: Vechile[];
  constructor(private vechileservice :VechileService) { }

  ngOnInit() {
      this.vechileservice.GetVechiles().subscribe(vechiles => this.vechiles = vechiles);
  }

}
