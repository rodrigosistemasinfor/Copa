import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { EquipeModel } from 'src/app/model/equipe.model';

@Component({
  selector: 'app-card-equipe',
  templateUrl: './card-equipe.component.html',
  styleUrls: ['./card-equipe.component.css']
})
export class CardEquipeComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  @Input()
  public elemento: EquipeModel;

  @Output('clickCheckbox')
  public onChange: EventEmitter<any> = new EventEmitter();

  public clickSelect(event, obj): void {
      this.onChange.emit({event, obj});
  }

}
