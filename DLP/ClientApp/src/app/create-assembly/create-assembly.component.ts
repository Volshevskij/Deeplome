import { Component, OnInit } from '@angular/core';
import { ContentService } from '../services/content/content.service';
import { Pc } from '../models/pc';
import { CompareMessages } from '../models/compareMessages';
import { HardwareViewModel } from '../models/HardwareViewModel';

@Component({
  selector: 'app-create-assembly',
  templateUrl: './create-assembly.component.html',
  styleUrls: ['./create-assembly.component.scss']
})
export class CreateAssemblyComponent implements OnInit {

  constructor(private service: ContentService) { }

  items: HardwareViewModel[] = [];
  newPc: Pc = new Pc();
  rtm: number;
  messages: CompareMessages[];
  ngOnInit() {
    this.getContent('Cargo', 0);
  }

  getContent(type: string, rt: number) {
    this.service.getProductByType(type).subscribe((data: any) => {
      this.items = data;
      this.rtm = rt;
      console.log(data);
    });
  }

  addToList(id: number, type: string) {
    console.log(id);
    console.log(type);
    if (type === 'Cargo') {
         this.newPc.corpusId = id;
         console.log(this.newPc.corpusId);
       }
    if (type === 'Motherboard') {
        this.newPc.motherboardId = id;
        console.log(this.newPc.motherboardId);
      }
    if (type === 'Power') {
        this.newPc.powerId = id;
        console.log(this.newPc.powerId);
      }
    if (type === 'CPU') {
        this.newPc.processorId = id;
        console.log(this.newPc.processorId);
      }
    if (type === 'RAM' && this.rtm === 1) {
        this.newPc.ram1Id = id;
        console.log(this.newPc.ram1Id);
      }
    if (type === 'RAM' && this.rtm === 2) {
        this.newPc.ram2Id = id;
        console.log(this.newPc.ram2Id);
      }
    if (type === 'RAM' && this.rtm === 3) {
        this.newPc.ram3Id = id;
        console.log(this.newPc.ram3Id);
      }
    if (type === 'RAM' && this.rtm === 4) {
        this.newPc.ram4Id = id;
        console.log(this.newPc.ram4Id);
      }
    if (type === 'GPU') {
        this.newPc.gPUId = id;
        console.log(this.newPc.gPUId);
      }
    if (type === 'Cooler') {
        this.newPc.coolerId = id;
        console.log(this.newPc.coolerId);
      }
  }

  saveAssembly() {
    console.log(this.newPc);
    this.service.saveAssembly(this.newPc).subscribe((data: any) => {
      this.messages = data;
      this.messages.forEach(element => {
        alert(element.message);
      });
      let count = 6;
      this.messages.forEach(element => {
        console.log(element.comparable);
        if (element.comparable === true) {
          count--;
        }
      });
      if (count === 0) {
        console.log('Set pc');
        console.log(this.newPc);
        this.newPc.name = '';
        this.service.setPc(this.newPc);
      }
    });
  }

}
