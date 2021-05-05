# MarsRover

Deploying and exploring Mars with a rover

## Assumptions

* For reference the Bottom Left of a Plateau has a default X,Y = 0,0 and the Top Right would be 3,3 (Considering a 3x3 plateau)

* The minimum plateau area is 4 (width * length).

* If movement command would bring the rover off grid, it will move until the edge, stop and return an error message.

* As for now it won't prevent rovers from crashing on each other.

* As for now, there is no rule of maximum number of rovers per plateau.

* As for now, rovers move synchonously one after the other.

* As for now, you can deploy a rover and move it upon launch, but not move it after deployed
** As part of that there is no persistence. Although easy to implement, entities have no ID yet as it's unclear as for now how/where it should be done.

## Possible improvements

* Can extract a big chunck of logic from `MoveRoverCommandHandler` by applying the strategy pattern for example.

* Missing Events
  * Setting-up notifications (e.g. RoverMovedEvent) to print on the console when a rover has moved for example.

* A movement command could have step to preview the path and prevent stopping at the edge before go off-grid or even prevent crashing in another rover on the way

## How to run

1. From a powershell command line run `.\run.ps1`
    * You may also run it inside docker with `.\run_docker.ps1`
2. Inform the plateau size and hit `[ENTER]` (e.g. 4 5)
3. Inform the position of the Rover and hit `[ENTER]` (e.g. 0 0 N)
4. Inform the directions you want it to move and hit `[ENTER]` (e.g. MML)

* If you want to ADD more rovers, just hit `[ENTER]`, otherwise type "`ok`" and hit `[ENTER]` to execute the mission.
