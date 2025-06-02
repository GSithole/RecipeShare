import { Component } from '@angular/core';
import { Recipe } from '../recipe';
import { RecipeService } from '../recipe.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-details',
  standalone: false,
  templateUrl: './details.component.html',
  styleUrl: './details.component.css'
})
export class DetailsComponent {

  constructor(private recipeService:RecipeService,private router:Router, private activatedRoute:ActivatedRoute) {
    
  }

  formdata : Recipe = {
      recipeId :0,
      title: '',
      ingredients:'',
      steps:'',
      cookingTimeMinutes:0,
      dietaryTags:''
    }

    ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe((param) =>{
      let id = Number(param.get('recipeId'))
      this.getById(id)
    })
  }

  getById(id:number){
    this.recipeService.GetRecipe(id).subscribe((response) => {
      this.formdata = response;
    })

}
}
