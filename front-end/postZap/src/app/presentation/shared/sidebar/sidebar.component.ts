import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  isCollapsed1 = true;
  isCollapsed2 = true;
  constructor() { }

  ngOnInit(): void {
  }
  
}
