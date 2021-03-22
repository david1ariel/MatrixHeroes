import { ChangeDetectorRef, Component, OnDestroy, OnInit } from '@angular/core';
import { Unsubscribe } from 'redux';
import { store } from 'src/app/redux/store';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent implements OnInit, OnDestroy {


  constructor(private cdRef: ChangeDetectorRef) { }

  async ngOnInit() {
  }

  ngOnDestroy(): void {
  }
}
