# Copilot Instructions for Better Projectile Origin

## Mod Overview and Purpose
**Mod Name:** Better Projectile Origin  
**Mod Description:**  
The Better Projectile Origin mod addresses the visual oddity in RimWorld where projectiles fired by pawns appear to originate from the center of the pawn instead of the weapon they are holding. While this is typically not noticeable in standard gameplay, visual mods like Camera+ magnify this discrepancy, especially when zoomed in. This mod rectifies the issue by scanning weapon textures at game-start and determining the appropriate origin point for projectiles, providing a more immersive experience. Although it slightly alters the projectile path based on weapon length, the impact on combat mechanics is negligible. This mod is also compatible with the Dual Wield mod and draws inspiration from the Projectile Offset Framework.

## Key Features and Systems
- **Dynamic Projectile Origin:** Automatically determine projectile origins based on weapon texture analysis.
- **Visual Consistency:** Ensures projectiles align with weapon barrels for improved visual fidelity.
- **Compatibility:** Designed to work alongside popular mods like Dual Wield.
- **Minimal Combat Impact:** The adjustment in projectile path has a negligible effect on gameplay balance.

## Coding Patterns and Conventions
- **Namespace and Class Organization:**  
  - Use descriptive class names and maintain a single purpose per class.  
  - Classes within the mod, like `BetterProjectileOriginMod` and `BetterProjectileOriginSettings`, follow CamelCase and are scoped appropriately as internal or public based on usage.
- **Method Naming:**  
  - Adopts PascalCasing for method names for consistency with C# standards.
- **Comments and Documentation:**  
  - Inline comments should clarify non-obvious logic, particularly texture scanning and pixel manipulation logic.

## XML Integration
- **XML Defs:**  
  Ensure XML configurations properly define new projectile origins without altering existing game data structures significantly.
- **Patch Operations:**  
  Use XPath patch operations to adjust projectile definition nodes where necessary.
  
## Harmony Patching
- **Harmony Setup:**  
  Use Harmony to safely and effectively inject custom logic into RimWorld’s existing methods, such as projectile launching and drawing.
- **Patch Methods:**  
  - Target specific methods like `Projectile_Launch` and augment their behavior to calculate and apply the new projectile origin.
  - Avoid conflicts by checking for existing patches using Harmony’s tools.

## Suggestions for Copilot
- **Code Completion:**  
  Provide intelligent code suggestions when writing texture analysis algorithms to identify non-transparent pixels efficiently.
- **Code Refactorings:**  
  Suggest refactoring opportunities to improve readability and performance, particularly in rendering-related classes like `PawnRenderUtility_DrawEquipmentAiming`.
- **Error Handling:**  
  Recommend error handling constructs when dealing with texture analysis to safeguard against unexpected file formats or missing texture resources.
- **Utility Functions:**  
  Propose utility function templates for recurring tasks such as logging or data validation to adhere to DRY principles.

By following these guidelines and leveraging Copilot’s suggestions, contributors can efficiently develop and maintain the Better Projectile Origin mod, ensuring high-quality, immersive enhancements for RimWorld players.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.
