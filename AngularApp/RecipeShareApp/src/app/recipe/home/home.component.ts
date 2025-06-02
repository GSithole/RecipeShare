import { Component, OnInit } from '@angular/core';
import { RecipeService } from '../recipe.service';
import { response } from 'express';
import { Recipe } from '../recipe';

@Component({
  selector: 'app-home',
  standalone: false,
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {

  recipes: Recipe[] =[];
  
  constructor(private recipeService:RecipeService) {
  }
  ngOnInit(): void {
    this.recipeService.GetAllRecipes().subscribe((response) => {
      this.recipes = response;
      console.log(response);
    })
  }

  deleteRecipe(id:number){
    this.recipeService.deleteRecipe(id).subscribe({
      next: (data) => {
        this.recipes = this.recipes.filter(x => x.recipeId != id)
      },
    })
  }

}
